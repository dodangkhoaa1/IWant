using System.Collections;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManagement : MonoBehaviour
{
    private void Start()
    {
        //Change language to be previous setting language
        ChangeLocal(PrefsKey.LOCALE_KEY);
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
        PrefsKey.LOCALE_KEY = _localeID;
        active = false;
    }
}
