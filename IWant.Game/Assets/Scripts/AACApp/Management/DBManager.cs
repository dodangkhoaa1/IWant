public static class DBManager
{
    public static string fullName = "Default Name";

    public static Gender gender;

    public static bool LoggedIn { get => fullName != null; }

    public static void LogOut()
    {
        fullName = null;
    }
}
