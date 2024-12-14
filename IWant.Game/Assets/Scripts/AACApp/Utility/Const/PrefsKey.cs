using Assets.Scripts.Utility.Const;
using UnityEngine;

public static class PrefsKey
{
    private const string locale_key = "locale_key";
    private const Gender gender = Gender.Male;

    public static int LOCALE_KEY
    {
        set => PlayerPrefs.SetInt(locale_key, value);
        get => PlayerPrefs.GetInt(locale_key, 0); // Replace 0 with a default value if needed.
    }

    //Return code(call API) of language based on LOCALE_KEY
    public static string LANGUAGE
    {
        get => LOCALE_KEY == 0 ? "en-us" : "vi-vn";
    }
    public static string GetVoiceByLanguageAndGender
    {
        get
        {
            if (gender == Gender.Male)
            //in MALE case
            {
                return PrefsKey.LOCALE_KEY == 0 ? AddressAPI.MALE_EN_US : AddressAPI.MALE_VI_VN; // 0 is english, 1 is vietnamese
            }
            else
            //in FEMALE case
            {
                return PrefsKey.LOCALE_KEY == 0 ? AddressAPI.FEMALE_EN_US : AddressAPI.FEMALE_VI_VN;
            }
        }
    }
}
