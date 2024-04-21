using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;

namespace SteelSoft_UnBoarding.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        [HttpGet("login", Name = "LogIn")]
        public ResAnswer Login(string login, string password)
        {
            User user = new();
            try
            {
                user = UserMenedger.Login(login, password);
            }
            catch (Exception ex)
            {
                return new ResAnswer()
                {
                    msg = ex.Message,
                    status = "ERROR"
                };
            }

            Response.Cookies.Append("login", user.GUID);
            return new ResAnswer()
            {
                msg = "Успешный вход",
                status = "SUCCESS"
            };
        }
    }
}
