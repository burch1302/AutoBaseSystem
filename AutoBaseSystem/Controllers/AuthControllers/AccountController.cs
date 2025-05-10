using AutoBase.Domain;
using AutoBase.Domain.Entities;
using AutoBaseSystem.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AutoBaseSystem.Controllers {
    public class AccountController : BaseController {
        private readonly AutoBaseSystemContext _context;

        public AccountController(AutoBaseSystemContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() {
            var model = new RegisterViewModel();

            if (User.IsInRole("Admin")) {
                model.Roles = _context.Set<UserRole>()
                    .Select(r => new SelectListItem {
                        Value = r.Id.ToString(),
                        Text = r.Name
                    }).ToList();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model) {
            if (!ModelState.IsValid) return View(model);

            if (_context.Users.Any(u => u.Login == model.Login)) {
                ModelState.AddModelError("Login", "Користувач з таким логіном вже існує.");
                return View(model);
            }
            var roleId = model.SelectedRoleId ??
                _context.Set<UserRole>().FirstOrDefault(r => r.Name == "User")?.Id ?? Guid.NewGuid();

            var user = new User {
                Login = model.Login,
                PasswordHash = HashPassword(model.Password),
                RoleId = roleId
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model) {
            if (!ModelState.IsValid) return View(model);

            var hash = HashPassword(model.Password);
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(u => u.Login == model.Login && u.PasswordHash == hash);

            if (user == null) {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(model);
            }

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role?.Name ?? "User")
            };

            var identity = new ClaimsIdentity(claims, "UserCookie");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("UserCookie", principal);

            return RedirectToAction("Index", "Home");
        }

        private string HashPassword(string password) {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        [HttpPost]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync("UserCookie");
            await HttpContext.SignOutAsync("Auth0", new AuthenticationProperties {
                RedirectUri = Url.Action("Index", "Home")
            });
            return RedirectToAction("Index", "Home");
        }
    }
}
