using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using static EmotionManager;

public class LibraryManagerEmotionGame : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Transform libraryContentPanel;  // Panel chứa ảnh
    [SerializeField] private Transform journalContentPanel;  // Panel chứa ảnh

    [Header("Assets")]
    [SerializeField] private List<Sprite> pieceSprites; // Danh sách ảnh của pieces
    [SerializeField] private List<string> pieceNames; // Danh sách tên của pieces
    [SerializeField] private List<AudioClip> pieceSounds; // Danh sách âm thanh tương ứng

    private EmotionManager emotionManager;

    private AudioManagerEmotionGame audioManager;
    private AudioManagement audio;

    void Start()
    {
        emotionManager = gameObject.GetComponent<EmotionManager>();
        audioManager = FindObjectOfType<AudioManagerEmotionGame>();
        if (SceneManager.GetActiveScene().name == SceneName.MainMenu.ToString())
        {
            audio = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioManagement>();
            PopulateScrollViewInMainMenu();
        }
        else
        {
            PopulateScrollView();
            emotionManager.StartLootLockerSessionAndExecute(() => emotionManager.LoadEmotionsAndExecute(() =>
            {
                PopulateJournalView(emotionManager.emotions);
            }));
        }
    }

    private void PopulateScrollView()
    {
        for (int i = 0; i < pieceSprites.Count; i++)
        {
            // Tạo một Object chứa cả ảnh và chữ
            GameObject pieceContainer = new GameObject("PieceContainer", typeof(RectTransform));
            pieceContainer.transform.SetParent(libraryContentPanel, false);

            // Thêm ảnh (có Button)
            GameObject newImageObj = new GameObject("PieceImage", typeof(Image), typeof(Button));
            newImageObj.transform.SetParent(pieceContainer.transform, false);

            Image imageComponent = newImageObj.GetComponent<Image>();
            imageComponent.sprite = pieceSprites[i];

            RectTransform imageRect = newImageObj.GetComponent<RectTransform>();
            imageRect.sizeDelta = new Vector2(700, 700); // Kích thước ảnh

            // Thêm sự kiện bấm vào ảnh để phát âm thanh
            Button button = newImageObj.GetComponent<Button>();
            int index = i; // Biến tạm để tránh lỗi closure trong lambda
            button.onClick.AddListener(() => PlayPieceSound(index));

            // Thêm text
            GameObject textObj = new GameObject("PieceText", typeof(TextMeshProUGUI));
            textObj.transform.SetParent(pieceContainer.transform, false);

            TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
            textComponent.text = pieceNames[i];
            textComponent.fontSize = 60;
            textComponent.color = Color.black;
            textComponent.fontStyle = FontStyles.Bold; // Corrected line to make text bold
            textComponent.alignment = TextAlignmentOptions.Center;

            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.sizeDelta = new Vector2(300, 60); // Kích thước chữ
            textRect.anchoredPosition = new Vector2(0, -370);  // Đặt chữ ngay bên dưới ảnh
        }
    }

    private void PlayPieceSound(int index)
    {
        if (audioManager != null && index < pieceSounds.Count && pieceSounds[index] != null)
        {
            audioManager.PlayLibrarySound(pieceSounds[index]);
        }
    }

    private void PopulateScrollViewInMainMenu()
    {
        for (int i = 0; i < pieceSprites.Count; i++)
        {
            // Tạo một Object chứa cả ảnh và chữ
            GameObject pieceContainer = new GameObject("PieceContainer", typeof(RectTransform));
            pieceContainer.transform.SetParent(libraryContentPanel, false);

            // Thêm ảnh (có Button)
            GameObject newImageObj = new GameObject("PieceImage", typeof(Image), typeof(Button));
            newImageObj.transform.SetParent(pieceContainer.transform, false);

            Image imageComponent = newImageObj.GetComponent<Image>();
            imageComponent.sprite = pieceSprites[i];

            RectTransform imageRect = newImageObj.GetComponent<RectTransform>();
            imageRect.sizeDelta = new Vector2(250, 250); // Kích thước ảnh

            // Thêm sự kiện bấm vào ảnh để phát âm thanh
            Button button = newImageObj.GetComponent<Button>();
            int index = i; // Biến tạm để tránh lỗi closure trong lambda
            button.onClick.AddListener(() =>
            {
                PlayPieceSoundInMainMenu(index);

                if (emotionManager != null)
                {
                    emotionManager.AddEmotion(pieceNames[index]);

                    emotionManager.emotionAskPanel.SetActive(false);

                    emotionManager.PrintEmotions();
                }

            });

            // Thêm text
            GameObject textObj = new GameObject("PieceText", typeof(TextMeshProUGUI));
            textObj.transform.SetParent(pieceContainer.transform, false);

            TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
            textComponent.text = pieceNames[i];
            textComponent.fontSize = 30;
            textComponent.color = Color.black;
            textComponent.fontStyle = FontStyles.Bold; // Corrected line to make text bold
            textComponent.alignment = TextAlignmentOptions.Center;

            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.sizeDelta = new Vector2(250, 60); // Kích thước chữ
            textRect.anchoredPosition = new Vector2(0, -140);  // Đặt chữ ngay bên dưới ảnh
        }
    }

    private void PlayPieceSoundInMainMenu(int index)
    {
        if (audio != null && index < pieceSounds.Count)
        {
            audio.PlayLibrarySound(pieceSounds[index]);
        }
    }

    private void PopulateJournalView(List<Emotion> emotions)
    {
        foreach (var emotion in emotions)
        {
            // Tạo một Object chứa cả ảnh và chữ
            GameObject emotionContainer = new GameObject("EmotionContainer", typeof(RectTransform));
            emotionContainer.transform.SetParent(journalContentPanel, false);

            // Thêm ảnh (có Button)
            GameObject newImageObj = new GameObject("EmotionImage", typeof(Image), typeof(Button));
            newImageObj.transform.SetParent(emotionContainer.transform, false);

            Image imageComponent = newImageObj.GetComponent<Image>();
            int spriteIndex = pieceNames.IndexOf(emotion.EmotionName);
            if (spriteIndex >= 0)
            {
                imageComponent.sprite = pieceSprites[spriteIndex];
            }

            RectTransform imageRect = newImageObj.GetComponent<RectTransform>();
            imageRect.sizeDelta = new Vector2(700, 700); // Kích thước ảnh

            // Thêm sự kiện bấm vào ảnh để phát âm thanh
            Button button = newImageObj.GetComponent<Button>();
            button.onClick.AddListener(() => PlayPieceSound(spriteIndex));

            // Thêm text cho tên cảm xúc
            GameObject textObj = new GameObject("EmotionText", typeof(TextMeshProUGUI));
            textObj.transform.SetParent(emotionContainer.transform, false);

            TextMeshProUGUI textComponent = textObj.GetComponent<TextMeshProUGUI>();
            textComponent.text = emotion.EmotionName;
            textComponent.fontSize = 60;
            textComponent.color = Color.black;
            textComponent.fontStyle = FontStyles.Bold; // Corrected line to make text bold
            textComponent.alignment = TextAlignmentOptions.Center;

            RectTransform textRect = textObj.GetComponent<RectTransform>();
            textRect.sizeDelta = new Vector2(300, 60); // Kích thước chữ
            textRect.anchoredPosition = new Vector2(0, -400);  // Đặt chữ ngay bên dưới ảnh

            // Thêm text cho ngày tháng
            GameObject dateTextObj = new GameObject("EmotionDateText", typeof(TextMeshProUGUI));
            dateTextObj.transform.SetParent(emotionContainer.transform, false);

            TextMeshProUGUI dateTextComponent = dateTextObj.GetComponent<TextMeshProUGUI>();
            dateTextComponent.text = emotion.Date.ToString("MM/dd/yyyy");
            dateTextComponent.fontSize = 70;
            dateTextComponent.color = Color.black;
            dateTextComponent.alignment = TextAlignmentOptions.Center;

            RectTransform dateTextRect = dateTextObj.GetComponent<RectTransform>();
            dateTextRect.sizeDelta = new Vector2(500, 100); // Kích thước chữ
            dateTextRect.anchoredPosition = new Vector2(0, 400);  // Đặt chữ ngay bên trên ảnh
        }
    }
}
