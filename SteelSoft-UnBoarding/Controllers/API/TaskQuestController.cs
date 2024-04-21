using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SteelSoft_UnBoarding.Data;
using SteelSoft_UnBoarding.Menedgers;
using SteelSoft_UnBoarding.Models;

namespace SteelSoft_UnBoarding.Controllers.API
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskQuestController : ControllerBase
	{
		[HttpGet("Complite")]
		public ResAnswer Get(int id_question)
		{
			User user = new User();
			if (Request.Cookies.TryGetValue("login", out string GUID))
			{
				try
				{
					user = UserMenedger.Users[GUID];
				}
				catch (Exception ex)
				{
					Response.Cookies.Delete("login");
					return new ResAnswer()
					{
						msg = "Пройдите аутентификацию",
						status = "ERROR"
					};
				}
				if (int.Parse(PostgreSQL.Query($"SELECT count(*) as count FROM infousers WHERE id_user = {user.ID}, id_task = {id_question}")[0]["count"]) == 0)
				{
                    return new ResAnswer()
                    {
                        msg = "Данная строка уже существует",
                        status = "ERROR"
                    };
                }
				PostgreSQL.QueryNotExicute($"INSERT INTO infousers VALUES({user.ID}, {id_question})");

				return new ResAnswer()
				{
					msg = "Успешно",
					status = "SUCCESS"
				};
			}
			return new ResAnswer()
			{
				msg = "Пройдите аутентификацию",
				status = "ERROR"
			};
		}
	}
}
