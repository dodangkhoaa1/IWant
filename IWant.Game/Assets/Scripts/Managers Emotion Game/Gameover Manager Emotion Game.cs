using System;
using UnityEngine;
using UnityEngine.UI;

public class GameoverManagerEmotionGame : MonoBehaviour
{
    private AudioManagerEmotionGame audioManager;  // Tham chiếu đến AudioManager

    [Header("UI Elements")]
    [SerializeField] private GameObject gameOverPanel;  // Panel Game Over

    void Start()
    {
        // Tìm AudioManager trong scene
        audioManager = FindObjectOfType<AudioManagerEmotionGame>();

        // Đảm bảo panel Game Over ban đầu tắt
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void TriggerGameOver()
    {
        Debug.LogError("Game Over!");

        // Hiển thị panel Game Over
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Phát nhạc ngay khi Game Over
        if (audioManager != null)
        {
            audioManager.PlayGameOverMusic();
        }

        // Gọi phương thức SetGameoverState từ GameManager
        GameManagerEmotionGame.instance.SetGameoverState();
    }
}
