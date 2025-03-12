using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using TMPro;

public class SettingsUnlocker : MonoBehaviour
{
    [Header("Dialog Components")]
    public GameObject dialogPanelPrefab;   // Dialog chứa mã PIN

    [Header("Colors")]
    [SerializeField] private Color inactiveColor;
    [SerializeField] private Color activeColor;

    private List<int> generatedCode = new List<int>(); // Dãy số đúng
    private List<int> userInput = new List<int>();     // Dãy số nhập vào
    private TextMeshProUGUI codeText;
    private GameObject dialogPanel;
    private Button[] numberButtons;   // 4 nút số
    private SettingsManagement settingsManagement; // Settings Panel

    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas != null)
        {
            dialogPanel = Instantiate(dialogPanelPrefab, canvas.transform);
            dialogPanel.SetActive(false);
            codeText = dialogPanel.transform.Find("Dialog/Display number").GetComponent<TextMeshProUGUI>();

            // Find and assign number buttons
            Transform numberButtonsContainer = dialogPanel.transform.Find("Dialog/Number Buttons Container");
            if (numberButtonsContainer != null)
            {
                numberButtons = numberButtonsContainer.GetComponentsInChildren<Button>();
            }
            else
            {
                Debug.LogError("Number Buttons Container not found.");
            }

            // Find and assign settingsManagement
            GameObject settingsManagementGO = GameObject.FindGameObjectWithTag("SettingsManagement");
            if (settingsManagementGO != null)
            {
                settingsManagement = settingsManagementGO.GetComponent<SettingsManagement>();
            }
            else
            {
                Debug.LogError("GameObject with tag 'SettingsManagement' not found.");
            }
        }
        else
        {
            Debug.LogError("Canvas with tag 'canvas' not found.");
        }
    }

    // Hiển thị dialog khi nhấn nút Settings
    public void ShowDialog()
    {
        GenerateRandomCode();
        ShuffleAndAssignNumbers();
        userInput.Clear();
        dialogPanel.SetActive(true);
    }

    // Tạo 3 số ngẫu nhiên
    void GenerateRandomCode()
    {
        generatedCode.Clear();
        for (int i = 0; i < 3; i++)
        {
            //ensure duplicate do not exist
            int randomNumber = Random.Range(0, 10);
            while (generatedCode.Contains(randomNumber))
            {
                randomNumber = Random.Range(0, 10);
            }

            generatedCode.Add(randomNumber); // Tạo số từ 0-9
        }
        codeText.text = string.Join("", generatedCode); // Hiển thị mã PIN
    }

    // Xáo trộn vị trí và gán số vào nút
    void ShuffleAndAssignNumbers()
    {
        List<int> shuffledNumbers = new List<int>(generatedCode);

        // Add a random number that is not in the generated code
        int randomExtraNumber = Random.Range(0, 10);
        while (generatedCode.Contains(randomExtraNumber))
        {
            randomExtraNumber = Random.Range(0, 10);
        }
        shuffledNumbers.Add(randomExtraNumber);
        shuffledNumbers = shuffledNumbers.OrderBy(x => Random.value).ToList();

        for (int i = 0; i < numberButtons.Length; i++)
        {
            int num = shuffledNumbers[i];  // Lưu giá trị riêng biệt
            Button btn = numberButtons[i]; // Lưu tham chiếu riêng biệt

            btn.GetComponent<Image>().color = inactiveColor;

            numberButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = num.ToString();
            numberButtons[i].onClick.RemoveAllListeners();
            numberButtons[i].onClick.AddListener(() => OnNumberPressed(num, btn));
        }
    }

    // Xử lý khi nhấn nút số
    void OnNumberPressed(int num, Button numberBtn)
    {
        userInput.Add(num);
        // Đổi màu nút khi được chọn
        numberBtn.GetComponent<Image>().color = activeColor;

        if (userInput.Count <= generatedCode.Count)
        {
            if (userInput[userInput.Count - 1] != generatedCode[userInput.Count - 1])
            {
                dialogPanel.SetActive(false);
                return;
            }
            if (userInput.Count == generatedCode.Count && userInput.SequenceEqual(generatedCode))
            {
                OpenSettings();
            }
        }
    }

    void OpenSettings()
    {
        dialogPanel.SetActive(false);
        settingsManagement.OpenSoundLanguageSetting();
    }
}
