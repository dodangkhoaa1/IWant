using LootLocker.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmotionManager : MonoBehaviour
{
    public GameObject emotionAskPanel;

    [HideInInspector]
    public List<Emotion> emotions;
    private const string LeaderboardKey = "30452";
    private bool isSessionStarted = false;


    void Awake()
    {
        if (SceneManager.GetActiveScene().name == SceneName.MainMenu.ToString())
        {
            StartLootLockerSessionAndExecute(() => LoadEmotionsAndExecute(() => CheckAndDisplayEmotionAskPanel()));
        }
    }

    public List<Emotion> GetEmotions()
    {
        List<Emotion> loadedEmotions = null;
        StartLootLockerSessionAndExecute(() => LoadEmotionsAndExecute(() => loadedEmotions = emotions));
        return loadedEmotions;
    }

    private void CheckAndDisplayEmotionAskPanel()
    {
        if (emotions == null || emotions.Count == 0)
        {
            emotionAskPanel?.SetActive(true);
            Debug.LogWarning($"Emotions Null");
            return;
        }

        bool hasTodayEmotion = emotions.Exists(e => e.Date.Date == DateTime.Today);
        //bool hasTodayEmotion = false; //for test
        Debug.LogWarning($"Has Today Emotion: {hasTodayEmotion}");
        emotionAskPanel?.gameObject.SetActive(!hasTodayEmotion);
    }

    public void StartLootLockerSessionAndExecute(Action callback)
    {
        LootLockerSDKManager.StartGuestSession(DBManager.User.UserId, (response) =>
        {
            if (response.success)
            {
                Debug.Log("✅ LootLocker session started successfully.");
                isSessionStarted = true;
                callback?.Invoke();
            }
            else
            {
                Debug.LogError("❌ Failed to start LootLocker session.");
                StartLootLockerSessionAndExecute(callback);
            }
        });
    }

    public void AddEmotion(string emotionName)
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        // Remove emotions older than 30 days
        DateTime thirtyDaysAgo = DateTime.Now.AddDays(-30);
        emotions = emotions.Where(e => e.Date >= thirtyDaysAgo).ToList();

        Emotion newEmotion = new Emotion
        {
            UserId = DBManager.User.UserId,
            EmotionName = emotionName,
            Date = DateTime.Now
        };

        //newEmotion.Date = thirtyDaysAgo.AddDays(-30);
        emotions.Add(newEmotion);

        SaveEmotions();
        SubmitScoreWithMetadata(emotions.Count, JsonConvert.SerializeObject(emotions));
    }

    public void LoadEmotionsAndExecute(Action callback)
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        LootLockerSDKManager.GetScoreList(LeaderboardKey, 50, (response) =>
        {
            if (response.success)
            {
                emotions = new List<Emotion>();
                if (response.items != null && response.items.Length > 0)
                {
                    foreach (var item in response.items)
                    {
                        List<Emotion> loadedEmotions = JsonConvert.DeserializeObject<List<Emotion>>(item.metadata) ?? new List<Emotion>();
                        foreach (var emotion in loadedEmotions)
                        {
                            if (emotion.UserId == DBManager.User.UserId)
                            {
                                emotions.Add(emotion);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogWarning("No data found in leaderboard.");
                }
                callback?.Invoke();
            }
            else
            {
                Debug.LogError("❌ Failed to load emotions from leaderboard.");
                LoadEmotionsAndExecute(callback);
            }
        });
    }

    private void SaveEmotions()
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        SubmitScoreWithMetadata(emotions.Count, JsonConvert.SerializeObject(emotions));
    }

    private void SubmitScoreWithMetadata(int score, string metadata)
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        LootLockerSDKManager.SubmitScore(DBManager.User.UserId, score, LeaderboardKey, metadata, (response) =>
        {
            if (response.success)
            {
                Debug.Log($"✅ Score {score} submitted successfully with metadata: {metadata}");
            }
            else
            {
                Debug.LogError($"❌ Failed to submit score. Error: " + response.errorData);
            }
        });
    }

    public void PrintEmotions()
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        Debug.Log("List Emotion");
        foreach (var emotion in emotions)
        {
            Debug.Log($"UserId: {emotion.UserId}, Emotion: {emotion.EmotionName}, Date: {emotion.Date}");
        }
        Debug.Log("End List Emotion");
    }


    [Serializable]
    public class Emotion
    {
        public string UserId;
        public string EmotionName;
        public DateTime Date;
    }
}
