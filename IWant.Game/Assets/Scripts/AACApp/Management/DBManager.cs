using UnityEngine;

public static class DBManager
{
    public static string fullName = "Default Name";

    public static Gender gender;

    private const string USER_DATA_STRING = "UserData";
    public static string USER_DATA
    {
        set => PlayerPrefs.SetString(USER_DATA_STRING, value);
        get => PlayerPrefs.GetString(USER_DATA_STRING, null);
    }

    public static bool LoggedIn { get => fullName != null; }

    public static void LogOut()
    {
        fullName = null;
    }
}
