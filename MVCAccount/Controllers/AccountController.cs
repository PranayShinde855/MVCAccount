using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVCAccount.Models;
using System.Security.Claims;

namespace MVCAccount.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            LoginDTO loginDTO = new LoginDTO();
            return View(loginDTO);
        }

        // Log in with session
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginDTO loginDTO)
        {
            if (loginDTO.Username == "Pranay" && loginDTO.Password == "Pranay")
                return View(loginDTO);

            HttpContext.Session.SetString("Username", loginDTO.Username);
            HttpContext.Session.SetString("Password", loginDTO.Password);
            return RedirectToAction(nameof(AfterLogin));
        }


        public IActionResult LoginCookies()
        {
            LoginDTO loginDTO = new LoginDTO();
            return View(loginDTO);
        }

        // Log in with cookies
        [HttpPost]
        public async Task<IActionResult> LoginCookies(LoginDTO loginDTO)
        {
            if (loginDTO.Username == "Pranay" && loginDTO.Password == "Pranay")
                return View(loginDTO);

            HttpContext.Session.SetString("Username", loginDTO.Username);
            HttpContext.Session.SetString("Password", loginDTO.Password);
            return RedirectToAction(nameof(AfterLogin));
        }

        public IActionResult AfterLogin()
        {
            return View();
        }
    }
}
