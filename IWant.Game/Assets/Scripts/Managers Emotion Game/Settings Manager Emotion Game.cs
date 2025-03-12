using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections;
using Connect.Core;

public class SettingsManagerEmotionGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Toggle sfxToggle;
    [SerializeField] private Toggle bgmToggle; // Toggle để bật/tắt nhạc nền
    [SerializeField] private Image[] iconSFX;
    [SerializeField] private Image[] iconBGM; // Biểu tượng cho nhạc nền
    [SerializeField] private Button iconClose;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Button replayButton;

    [Header(" Actions ")]
    public static Action<bool> onSFXValueChanged;
    public static Action<bool> onBGMValueChanged; // Sự kiện cho nhạc nền

    [Header(" Data ")]
    private const string sfxActiveKey = "sfxActiveKey";
    private const string bgmActiveKey = "bgmActiveKey"; // Key lưu trạng thái nhạc nền
    private bool canSave = false;

    private void Awake()
    {
        LoadData(); // Chỉ load dữ liệu, chưa cho phép lưu
        iconClose.onClick.AddListener(CloseSettings);

        replayButton.onClick.AddListener(ReplayGame);

        // Gán sự kiện cho toggle
        sfxToggle.onValueChanged.AddListener(ToggleSFXCallback);
        bgmToggle.onValueChanged.AddListener(ToggleBGMCallback);
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f); // Chờ 0.5s trước khi cho phép lưu
        canSave = true;
    }

    private void LoadData()
    {
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
        if (!canSave) return; // Tránh ghi đè sai dữ liệu khi chưa sẵn sàng

        PlayerPrefs.SetInt(sfxActiveKey, sfxToggle.isOn ? 1 : 0);
        PlayerPrefs.SetInt(bgmActiveKey, bgmToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log($"[SaveData] SFX: {PlayerPrefs.GetInt(sfxActiveKey)}, BGM: {PlayerPrefs.GetInt(bgmActiveKey)}");
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

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ReplayGame()
    {
        SaveData(); // Lưu trạng thái trước khi reload
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenus");
    }
}
