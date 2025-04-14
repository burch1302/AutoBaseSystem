using AutoBase.Domain;
using AutoBase.Domain.Entities;
using AutoBaseSystem.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace AutoBaseSystem.Controllers {
    public class AccountController : BaseController {
        private readonly AutoBaseSystemContext _context;

        public AccountController(AutoBaseSystemContext context) {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model) {
            if (!ModelState.IsValid) return View(model);

            if (_context.Users.Any(u => u.Login == model.Login)) {
                ModelState.AddModelError("Login", "Такой пользователь уже существует.");
                return View(model);
            }

            var defaultRole = _context.Set<UserRole>().FirstOrDefault(r => r.Name == "User");

            var user = new User {
                Login = model.Login,
                PasswordHash = HashPassword(model.Password),
                RoleId = defaultRole != null ? defaultRole.Id : Guid.NewGuid() // временно
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
        public IActionResult Login(LoginViewModel model) {
            if (!ModelState.IsValid) return View(model);

            var hash = HashPassword(model.Password);
            var user = _context.Users.FirstOrDefault(u => u.Login == model.Login && u.PasswordHash == hash);

            if (user == null) {
                ModelState.AddModelError("", "Неверный логин или пароль");
                return View(model);
            }

            // Тут позже добавим куки
            return RedirectToAction("Index", "Home");
        }

        private string HashPassword(string password) {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
