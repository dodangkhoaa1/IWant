using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    [SerializeField] private Sprite vietnameseFlag;
    [SerializeField] private Sprite americaFlag;
    [SerializeField] private Image displayFlag;
    [SerializeField] private Color vietnameseColor;
    [SerializeField] private Color americaColor;

    private void Start()
    {
        // Change language to be previous setting language
        StartCoroutine(ChangeLocal(PrefsKey.LOCALE_KEY));
    }
    private bool active = false;

    // Allow to change language to English
    public void ChangeToEnglish(bool is_reload = false)
    {
        StartCoroutine(ChangeLocalAndReload(0, is_reload));
    }

    // Allow to change language to Vietnamese
    public void ChangeToVietnamese(bool is_reload = false)
    {
        StartCoroutine(ChangeLocalAndReload(1, is_reload));
    }

    // Allow to change locale and reload the scene if needed
    private IEnumerator ChangeLocalAndReload(int localeID, bool is_reload)
    {
        yield return ChangeLocal(localeID);
        if (is_reload)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // Allow to change locale
    private IEnumerator ChangeLocal(int localeID)
    {
        if (active) yield break;
        yield return SetLocale(localeID);
    }

    // Allow to set the locale
    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        PrefsKey.LOCALE_KEY = _localeID;
        UpdateFlag(_localeID);
        active = false;
    }

    // Update the flag based on the locale
    private void UpdateFlag(int localeID)
    {
        if (localeID == 0)
        {
            displayFlag.sprite = americaFlag;
        }
        else if (localeID == 1)
        {
            displayFlag.sprite = vietnameseFlag;
        }

        // Get posX of the parent of displayFlag and set based on localeID
        RectTransform parentRectTransform = displayFlag.transform.parent.GetComponent<RectTransform>();
        if (parentRectTransform != null)
        {
            Vector3 parentPos = parentRectTransform.localPosition;
            parentPos.x = localeID == 0 ? -Mathf.Abs(parentPos.x) : Mathf.Abs(parentPos.x);
            parentRectTransform.localPosition = parentPos;

            // Set background color of the parent of parentRectTransform
            Transform grandParentTransform = parentRectTransform.parent;
            if (grandParentTransform != null)
            {
                Image grandParentImage = grandParentTransform.GetComponent<Image>();
                if (grandParentImage != null)
                {
                    grandParentImage.color = localeID == 0 ? americaColor : vietnameseColor;
                }
            }
        }
    }

    public void SwitchLanguageButton(bool is_reload = false)
    {
        int currentLocale = PrefsKey.LOCALE_KEY;
        int newLocale = currentLocale == 0 ? 1 : 0; // Toggle between 0 (English) and 1 (Vietnamese)
        StartCoroutine(ChangeLocalAndReload(newLocale, is_reload));
    }
}
