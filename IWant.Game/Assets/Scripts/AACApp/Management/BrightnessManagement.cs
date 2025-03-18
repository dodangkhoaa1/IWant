using EasyUI.Toast;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BrightnessManagement : MonoBehaviour
{
    private const string BrightnessPrefKey = "BrightnessValue";
    [SerializeField] private GameObject brightnessPanelPrefab;
    [SerializeField] private Slider brightnessSlider;
    private Image brightnessPanel;

    private void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas != null)
        {
            GameObject panel = Instantiate(brightnessPanelPrefab, canvas.transform);
            brightnessPanel = panel.GetComponent<Image>();
            float savedBrightness = PlayerPrefs.GetFloat(BrightnessPrefKey, 1f); // Default to brightest
            if (brightnessSlider != null)
            {
                brightnessSlider.value = savedBrightness;
                brightnessSlider.onValueChanged.AddListener(SetBrightness);
            }
            SetBrightness(savedBrightness);
        }
    }

    public void SetBrightness(float value)
    {
        if (brightnessPanel != null)
        {
            Color color = brightnessPanel.color;
            if (SceneManager.GetActiveScene().name == SceneName.ColoringScene.ToString())
            {
                color.a = 0; // 0 = brightest, 0.7 = darkest
                brightnessPanel.color = color;
                string toastStr = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                    ? "Full brightness is required to color!"
                    : "Độ sáng cao nhất là bắt buộc để tô màu!";
                Toast.Show(toastStr, 1.5f, ToastColor.Green, ToastPosition.BottomCenter);
            }
            else
            {
                color.a = 0.7f * (1 - value); // 0 = brightest, 0.7 = darkest
                brightnessPanel.color = color;
                PlayerPrefs.SetFloat(BrightnessPrefKey, value);
            }
        }
    }

}
