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
    }
}
