using Newtonsoft.Json;
using UnityEngine;

public static class DBManager
{
    public static string lastname = "My Friend";

    public static string GetDisplayName(UserResponseDTO UserInfo)
    {
        return !string.IsNullOrEmpty(UserInfo.ChildNickName) ? UserInfo.ChildNickName :
               !string.IsNullOrEmpty(UserInfo.ChildName) ? UserInfo.ChildName : UserInfo.FullName;
    }

    public static UserResponseDTO User
    {
        set { }
        get => JsonConvert.DeserializeObject<UserResponseDTO>(USER_DATA);
    }

    public static Gender gender
    {
        set{}
        get
        {
            UserResponseDTO UserInfo = User;
            if (UserInfo == null){
                return Gender.Male;
            }
            return UserInfo.ChildGender.HasValue ? (UserInfo.ChildGender.Value ? Gender.Male : Gender.Female) : (UserInfo.Gender.HasValue ? (UserInfo.Gender.Value ? Gender.Male : Gender.Female) : Gender.Female);
        }
    }

    private const string USER_DATA_STRING = "UserData";
    public static string USER_DATA
    {
        set => PlayerPrefs.SetString(USER_DATA_STRING, value);
        get => PlayerPrefs.GetString(USER_DATA_STRING, null);
    }

    public static bool LoggedIn { get => USER_DATA != null; }

    public static void LogOut()
    {
        lastname = null;
    }
}
