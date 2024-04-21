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
				return RedirectToAction("Profile", "User");
            }

			return View();
        }
        public IActionResult LogOut()
        {
            if (Request.Cookies.TryGetValue("login", out string res))
            {
                UserMenedger.LogOut(res);
                Response.Cookies.Delete("login");
            }
            return RedirectToAction("Index", "Home");
            //return new ResAnswer() {
            //    msg = "Успешный выход",
            //    status = "SUCCESS"
            //};
        }
        public IActionResult Profile(int id = -2)
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
                return View(new TaskModel(id, UserMenedger.Users[GUID]));
            }
            return RedirectToAction("Login");
        }
    }
}
