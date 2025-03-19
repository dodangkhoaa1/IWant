using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerEmotionGame : MonoBehaviour
{
    public static LevelManagerEmotionGame instance;

    [SerializeField] private List<GameObject> levelPrefabs; // Danh sách các level prefab
    [SerializeField] private Transform levelParent; // Parent chứa level

    private int currentLevelIndex = 0;
    private GameObject currentLevelInstance;

    public GameObject CurrentLevelInstance { get { return currentLevelInstance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void LoadCurrentLevel()
    {
        // Xóa instance cũ nếu có
        if (currentLevelInstance != null)
        {
            Destroy(currentLevelInstance);
            currentLevelInstance = null;
        }

        if (currentLevelIndex < levelPrefabs.Count)
        {
            currentLevelInstance = Instantiate(levelPrefabs[currentLevelIndex], levelParent);
            Debug.Log("Loaded Level: " + currentLevelInstance.name);
        }
        else
        {
            // Không còn level nữa, báo hiệu đã hoàn thành toàn bộ các level
            Debug.Log("All levels completed!");
            // Thông báo cho GameManager chuyển sang trạng thái Gameover
            GameManagerEmotionGame.instance.SetGameoverState();
        }
    }
    public void ResetLevelIndex()
    {
        currentLevelIndex = 0;
        Debug.Log("Reset level index to 0");
    }
    // Dọn dẹp các đối tượng của level cũ
    public void ClearCurrentLevel()
    {
        if (levelParent != null)
        {
            for (int i = levelParent.childCount - 1; i >= 0; i--)
            {
                Destroy(levelParent.GetChild(i).gameObject);
            }
            Debug.Log("Cleared current level.");
        }
        else
        {
            Debug.LogWarning("levelParent is not assigned.");
        }
    }

    public void LoadNextLevel()
    {
        currentLevelIndex++;
        Debug.Log("LoadNextLevel() called. New level index: " + currentLevelIndex);
        if (currentLevelIndex < levelPrefabs.Count)
        {
            LoadCurrentLevel();
        }
        else
        {
            Debug.Log("No more levels!");
            // Chuyển sang trạng thái Gameover
            GameManagerEmotionGame.instance.SetGameoverState();
        }
    }
    public void ResetLevel()
    {
        currentLevelIndex = 0;
        Debug.Log("Reset level index to 0");
    }

    // Phương thức chuyển level được gọi từ PuzzleManager
    public void TransitionLevel()
    {
        // Có thể dọn dẹp level cũ nếu cần, sau đó load level mới
        ClearCurrentLevel();
        LoadNextLevel();
        TimeManagerEmotionGame.instance.StartTimer();
    }
}
