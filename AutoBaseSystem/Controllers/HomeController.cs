using AutoBaseSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AutoBaseSystem.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        public IActionResult Login() {
            return View(); // Пока можно создать заглушку Login.cshtml
        }

        public IActionResult Register() {
            return View(); // То же для Register.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
