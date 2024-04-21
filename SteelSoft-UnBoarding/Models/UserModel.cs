using SteelSoft_UnBoarding.Data;

namespace SteelSoft_UnBoarding.Models
{
    public class UserModel
    {
        public UserModel(User user)
        {
            User = user;
        }
        public User User { get; set; } 
        public int GetBalls()
        {
            var resQuery = PostgreSQL.Query($"SELECT sum(score) as sum FROM questions JOIN infousers as ui on ui.id_user = {User.ID} and ui.id_task = questions.id");

            return int.Parse(resQuery[0]["sum"]);
        }
    }
}
