using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;

public class LanguageManager : MonoBehaviour
{
    private void Start()
    {
        //Change language to be previous setting language
        ChangeLocal(PrefsKey.LOCALE_KEY);
    }
    private bool active = false;

    public void ChangeToEnglish(bool is_reload = false)
    {
        StartCoroutine(ChangeLocalAndReload(0, is_reload));
    }
    public void ChangeToVietnamese(bool is_reload = false)
    {
        StartCoroutine(ChangeLocalAndReload(1, is_reload));
    }

    private IEnumerator ChangeLocalAndReload(int localeID, bool is_reload)
    {
        yield return ChangeLocal(localeID);
        if (is_reload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private IEnumerator ChangeLocal(int localeID)
    {
        if (active) yield break;
        yield return SetLocale(localeID);
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
