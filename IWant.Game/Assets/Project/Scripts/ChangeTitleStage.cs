using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeTitleStage : MonoBehaviour
{
    
    [SerializeField] private TMP_Text _stageNameText;
    [SerializeField] private Image _stageColorImage;

    private void Start()
    {
        UpdateStageUI();
    }

    public void UpdateStageUI()
    {
        // Retrieve information from PlayerPrefs
        string stageName = PlayerPrefs.GetString("StageName", "Default Stage Name");
        string stageColorString = PlayerPrefs.GetString("StageColor", "#FFFFFF");
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1); // Default to level 1 if not saved

        // Convert color
        Color stageColor;
        ColorUtility.TryParseHtmlString("#" + stageColorString, out stageColor);

        // Update UI
        _stageNameText.text = $"{stageName} - {currentLevel}"; // Example: "Easy - 14"
        _stageColorImage.color = stageColor;
    }
}

