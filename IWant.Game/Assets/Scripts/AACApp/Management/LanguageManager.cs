using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageManager : MonoBehaviour
{
    private void Start()
    {
        //Change language to be previous setting language
        ChangeLocal(PrefsKey.LOCALE_KEY);
    }
    private bool active = false;

    public void ChangeToEnglish()
    {
        ChangeLocal(0);
    }
    public void ChangeToVietnamese()
    {
        ChangeLocal(1);
    }

    private void ChangeLocal(int localeID)
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
