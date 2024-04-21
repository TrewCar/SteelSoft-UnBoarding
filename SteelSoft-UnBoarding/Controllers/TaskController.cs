using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;
using SteelSoft_UnBoarding.Models;

namespace SteelSoft_UnBoarding.Controllers
{
    [Route("[controller]")]
    public class TaskController : Controller
    {
        [Route("{id}")]
        public IActionResult Task(int id)
        {
            if (Request.Cookies.TryGetValue("login", out string GUID))
            {
                try
                {
                    User user = UserMenedger.Users[GUID];
                    new TaskModel(id, user).Task();
                }
                catch (Exception ex)
                {
                    Response.Cookies.Delete("login");
                    return RedirectToAction("Index", "home");
                }
                return View(new TaskModel(id, UserMenedger.Users[GUID]));
            }
            return RedirectToAction("Index", "home");
        }
    }
}
