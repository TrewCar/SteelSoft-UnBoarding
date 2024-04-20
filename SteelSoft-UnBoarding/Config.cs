namespace SteelSoft_UnBoarding
{
    public static class Config
    {
        public static string HOST { get; private set; } = "localhost";
        public static string PORT { get; private set; } = "5432";
        public static string USER { get; private set; } = "postgres";
        public static string PASS { get; private set; } = "0000";
        public static string DATABASE { get; private set; } = "onboarding";
    }
}
