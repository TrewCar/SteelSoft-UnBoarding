using SteelSoft_UnBoarding.Data;

namespace SteelSoft_UnBoarding.Menedgers
{
    public static class UserMenedger
    {
        public static Dictionary<string, User> Users = new();
        public static User Login(string login, string password)
        {
            var reQuery = PostgreSQL.Query($"SELECT * FROM users where login = '{login}' and password = '{password}'");
            if( reQuery == null || reQuery.Count == 0)
            {
                throw new Exception("Не верный логин или пароль");
            }
            User user = new User()
            {
                ID = reQuery[0]["id"],
                Name = reQuery[0]["lastname"] + " " + reQuery[0]["name"] + " " + reQuery[0]["midname"],
            };
            Users.Add(user.GUID, user);
            return user;
        }
        public static void LogOut(string GUID)
        {
            Users.Remove(GUID);
        }
    }
}
