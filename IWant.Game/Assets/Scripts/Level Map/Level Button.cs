    using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class LevelButton : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI levelIndexText;
    [SerializeField] private Button button;
    [SerializeField] private Image lockIcon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Image>().color = Random.ColorHSV(0f,1f,.5f,1f,.8f,1f);
    }
    public void Configure(int levelIndex, int requiredScore, int bestScore)
    {
        levelIndexText.text = levelIndex.ToString();
        bool isUnlocked = bestScore >= requiredScore;

        // Hiển thị hoặc ẩn hình ổ khóa
        lockIcon.gameObject.SetActive(!isUnlocked);

        // Nếu đã mở khóa thì có thể nhấn, ngược lại thì vô hiệu hóa button
        button.interactable = isUnlocked;
    }


    public void Enable()
    {
        button.interactable = true;
        lockIcon.gameObject.SetActive(false); // Ẩn ổ khóa khi mở khóa level
    }

    public Button GetButton() => button;
}
