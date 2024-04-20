using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;
using SteelSoft_UnBoarding.Models;

namespace SteelSoft_UnBoarding.Controllers
{
    [Route("[controller]")]
    public class QuestionController : Controller
    {
        [Route("{id}")]
        public IActionResult Question(int id)
        {
            if(Request.Cookies.TryGetValue("login", out string GUID))
            {
                try
                {
                    User user = UserMenedger.Users[GUID];
                }catch (Exception ex)
                {
                    Response.Cookies.Delete("login");
                    return RedirectToAction("Index", "home");
                }
                return View(new QuestionModel(id, UserMenedger.Users[GUID]));
            }
            return RedirectToAction("Index", "home");  
        }
    }
}
