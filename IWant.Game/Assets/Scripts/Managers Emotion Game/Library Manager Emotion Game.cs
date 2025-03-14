using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class LibraryManagerEmotionGame : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private Transform contentPanel;  // Panel chứa ảnh
    [SerializeField] private List<Sprite> pieceSprites; // Danh sách ảnh của pieces
    [SerializeField] private List<string> pieceNames; // Danh sách tên của pieces
    [SerializeField] private List<AudioClip> pieceSounds; // Danh sách âm thanh tương ứng


    private AudioManagerEmotionGame audioManager;

    void Start()
    {
        audioManager = FindObjectOfType<AudioManagerEmotionGame>();
        PopulateScrollView();
    }

    private void PopulateScrollView()
    {
        for (int i = 0; i < pieceSprites.Count; i++)
        {
            // Tạo một Object chứa cả ảnh và chữ
            GameObject pieceContainer = new GameObject("PieceContainer", typeof(RectTransform));
            pieceContainer.transform.SetParent(contentPanel, false);

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
        if (audioManager != null && index < pieceSounds.Count)
        {
            audioManager.PlayLibrarySound(pieceSounds[index]);
        }
    }
}
