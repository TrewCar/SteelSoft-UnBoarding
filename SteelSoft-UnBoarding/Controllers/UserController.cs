using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;
using SteelSoft_UnBoarding.Models;
using System;

namespace SteelSoft_UnBoarding.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Profile()
        {
            if (Request.Cookies.TryGetValue("login", out string GUID))
            {
                try
                {
                    User user = UserMenedger.Users[GUID];
                }
                catch (Exception ex)
                {
                    Response.Cookies.Delete("login");
                    return RedirectToAction("Login");
                }
                return View(new UserModel(UserMenedger.Users[GUID]));
            }
            return RedirectToAction("Login");
        }
    }
}
