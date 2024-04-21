using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;
using SteelSoft_UnBoarding.Models;
using System.Diagnostics;

namespace SteelSoft_UnBoarding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
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
					return View();
				}
				return View(new UserModel(UserMenedger.Users[GUID]));
			}
			return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
