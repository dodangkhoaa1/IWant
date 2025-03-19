using LootLocker.Requests;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    public GameObject emotionAskPanel;


    private List<Emotion> emotions;
    private const string LeaderboardKey = "30452";
    private int timeToTry = 3;
    private bool isSessionStarted = false;

    void Start()
    {
        StartLootLockerSession();
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
        Debug.LogWarning($"Has Today Emotion: {hasTodayEmotion}");
        emotionAskPanel?.gameObject.SetActive(!hasTodayEmotion);
    }
    private void StartLootLockerSession()
    {
        LootLockerSDKManager.StartGuestSession(DBManager.User.UserId, (response) =>
        {
            if (response.success)
            {
                Debug.Log("✅ LootLocker session started successfully.");
                isSessionStarted = true;
                LoadEmotions();
            }
            else
            {
                Debug.LogError("❌ Failed to start LootLocker session.");
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

        Emotion newEmotion = new Emotion
        {
            UserId = DBManager.User.UserId,
            EmotionName = emotionName,
            Date = DateTime.Now
        };
        emotions.Add(newEmotion);
        SaveEmotions();
        SubmitScoreWithMetadata(emotions.Count, JsonConvert.SerializeObject(emotions));
    }

    private void LoadEmotions()
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return;
        }

        if (timeToTry == 0) return;
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
                CheckAndDisplayEmotionAskPanel();
            }
            else
            {
                timeToTry--;
                Debug.LogError("❌ Failed to load emotions from leaderboard.");
                LoadEmotions();
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

    public List<Emotion> GetEmotions()
    {
        if (!isSessionStarted)
        {
            Debug.LogError("❌ LootLocker session not started yet.");
            return null;
        }

        return emotions;
    }

    [Serializable]
    public class Emotion
    {
        public string UserId;
        public string EmotionName;
        public DateTime Date;
    }
}
