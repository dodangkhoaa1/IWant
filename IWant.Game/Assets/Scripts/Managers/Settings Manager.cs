using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;

public class SettingsManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject resetProgressPrompt;
    [SerializeField] private Slider pushMagnitudeSlider;

    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle bgmToggle; // Toggle để bật/tắt nhạc nền
    [SerializeField] private Image[] iconSFX;
    [SerializeField] private Image[] iconBGM; // Biểu tượng cho nhạc nền
    [SerializeField] private Button iconClose;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Button replayButton;

    [Header(" Actions ")]
    public static Action<float> onPushMagnitudeChanged;
    public static Action<bool> onSFXValueChanged;
    public static Action<bool> onBGMValueChanged; // Sự kiện cho nhạc nền

    [Header(" Data ")]
    private const string lastPushMagnitudeKey = "lastPushMagnitude";
    private const string sfxActiveKey = "sfxActiveKey";
    private const string bgmActiveKey = "bgmActiveKey"; // Key lưu trạng thái nhạc nền
    private bool canSave;

    private void Awake()
    {
        LoadData();
        iconClose.onClick.AddListener(CloseSettings);
        replayButton.onClick.AddListener(ReplayGame);

        // Gán sự kiện cho toggle
        sfxToggle.onValueChanged.AddListener(ToggleSFXCallback);
        bgmToggle.onValueChanged.AddListener(ToggleBGMCallback);
    }

    IEnumerator Start()
    {
        Initialize();
        yield return new WaitForSeconds(.5f);
        canSave = true;
    }

    private void Initialize()
    {
        onPushMagnitudeChanged?.Invoke(pushMagnitudeSlider.value);
        onSFXValueChanged?.Invoke(sfxToggle.isOn);
        onBGMValueChanged?.Invoke(bgmToggle.isOn); // Gửi trạng thái nhạc nền
        UpdateIconSFX(sfxToggle.isOn);
        UpdateIconBGM(bgmToggle.isOn);
    }
    //public void ResetProgressButtonCallback()
    //{
    //    resetProgressPrompt.SetActive(true);
    //}

    //public void ResetProgressYes()
    //{
    //    PlayerPrefs.DeleteAll();
    //    SceneManager.LoadScene(0);
    //}

    //public void ResetProgressNo()
    //{
    //    resetProgressPrompt.SetActive(false);
    //}

    public void SliderValueChangedCallback()
    {
        onPushMagnitudeChanged?.Invoke(pushMagnitudeSlider.value);
        if (canSave)
            SaveData();
    }

    public void ToggleSFXCallback(bool sfxActive)
    {
        onSFXValueChanged?.Invoke(sfxActive);
        UpdateIconSFX(sfxActive);
        SaveData();
    }

    public void ToggleBGMCallback(bool bgmActive)
    {
        onBGMValueChanged?.Invoke(bgmActive);
        UpdateIconBGM(bgmActive);
        SaveData();
    }

    private void LoadData()
    {
        pushMagnitudeSlider.value = PlayerPrefs.GetFloat(lastPushMagnitudeKey, 1);
        // Tạm thời xóa sự kiện để tránh trigger khi gán giá trị
        sfxToggle.onValueChanged.RemoveListener(ToggleSFXCallback);
        bgmToggle.onValueChanged.RemoveListener(ToggleBGMCallback);

        // Load trạng thái từ PlayerPrefs
        int sfxValue = PlayerPrefs.GetInt(sfxActiveKey, 1);
        int bgmValue = PlayerPrefs.GetInt(bgmActiveKey, 1);

        Debug.Log($"[LoadData] SFX: {sfxValue}, BGM: {bgmValue}"); // Debug kiểm tra

        sfxToggle.isOn = sfxValue == 1;
        bgmToggle.isOn = bgmValue == 1;

        // Cập nhật UI & gửi sự kiện
        onSFXValueChanged?.Invoke(sfxToggle.isOn);
        onBGMValueChanged?.Invoke(bgmToggle.isOn);
        UpdateIconSFX(sfxToggle.isOn);
        UpdateIconBGM(bgmToggle.isOn);

        // Gán lại sự kiện sau khi load xong
        sfxToggle.onValueChanged.AddListener(ToggleSFXCallback);
        bgmToggle.onValueChanged.AddListener(ToggleBGMCallback);
    }

    private void SaveData()
    {
        if (!canSave) return;

        PlayerPrefs.SetFloat(lastPushMagnitudeKey, pushMagnitudeSlider.value);
        PlayerPrefs.SetInt(sfxActiveKey, sfxToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt(bgmActiveKey, bgmToggle.isOn ? 1 : 0);
        // Lưu trạng thái nhạc nền
        PlayerPrefs.Save();
    }

    private void UpdateIconSFX(bool sfxActive)
    {
        foreach (var icon in iconSFX) icon.gameObject.SetActive(false);
        iconSFX[sfxActive ? 0 : iconSFX.Length - 1].gameObject.SetActive(true);
    }

    private void UpdateIconBGM(bool bgmActive)
    {
        foreach (var icon in iconBGM) icon.gameObject.SetActive(false);
        iconBGM[bgmActive ? 0 : iconBGM.Length - 1].gameObject.SetActive(true);
    }

    private void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }
    public void ReplayGame()
    {
        // Đặt lại trạng thái game mà không xóa dữ liệu đã lưu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
