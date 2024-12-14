using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManagement : MonoBehaviour
{
    public enum Languages{
        English,
        Vietnamese
    }
    private const string LOCALE_KEY = "LocaleKey";
    private void Start()
    {
        int ID = PlayerPrefs.GetInt(LOCALE_KEY, 0);
        ChangeLocal(ID);
    }
    private bool active = false;
    public void ChangeLocal(int localeID)
    {
        if (active) return;
        StartCoroutine(SetLocale(localeID));
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        PlayerPrefs.SetInt(LOCALE_KEY, _localeID);
        active = false;
    }
}
