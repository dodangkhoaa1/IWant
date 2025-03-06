using TMPro;
using UnityEngine;
using System;

public class HUDManagerEmotionGame : MonoBehaviour
{
    public static HUDManagerEmotionGame instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timeText;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void OnEnable()
    {
        if (TimeManagerEmotionGame.instance != null)
            TimeManagerEmotionGame.instance.OnTimeUpdate += UpdateTimeDisplay;
    }

    private void OnDisable()
    {
        if (TimeManagerEmotionGame.instance != null)
            TimeManagerEmotionGame.instance.OnTimeUpdate -= UpdateTimeDisplay;
    }

    private void UpdateTimeDisplay(float elapsedTime)
    {
        // Tính tổng số mili giây kể từ đầu
        int totalMilliseconds = (int)(elapsedTime * 1000);

        // Tính số giây và mili giây
        int seconds = totalMilliseconds / 1000;  // Lấy số giây
        int milliseconds = totalMilliseconds % 1000; // Lấy phần mili giây

        // Cập nhật UI chỉ với giây:mili giây
        timeText.text = string.Format("{0:D2}:{1:D3}", seconds, milliseconds);
    }

    public void UpdateScoreDisplay(int score)
    {
        scoreText.text = score.ToString();
    }
}
