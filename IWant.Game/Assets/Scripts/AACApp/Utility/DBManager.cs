using UnityEngine;

public static class DBManager
{
    public static string username;
    public static int score;

    public static bool LoggedIn { get => username != null; }

    public static void LogOut()
    {
        username = null;
    }
}
