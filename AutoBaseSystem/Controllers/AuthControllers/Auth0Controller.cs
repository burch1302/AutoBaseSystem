using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoBaseSystem.Controllers;

public class Auth0Controller : Controller {

    [HttpGet]
    public IActionResult Login() {
        return Challenge(new AuthenticationProperties {
            RedirectUri = "/"
        }, "Auth0");
    }

    [Authorize]
    [HttpPost]
    public IActionResult Logout() {
        return SignOut(new AuthenticationProperties {
            RedirectUri = "/"
        },
        "Auth0", // 💡 выходим из Auth0
        CookieAuthenticationDefaults.AuthenticationScheme // 💡 и локальной куки
        );
    }
}
