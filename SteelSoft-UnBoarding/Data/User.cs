namespace SteelSoft_UnBoarding.Data
{
    public class User
    {
        public string ID;
        public string Name;
        public string GUID = Guid.NewGuid().ToString();
    }
}
