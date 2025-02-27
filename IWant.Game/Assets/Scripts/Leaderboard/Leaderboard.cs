using LootLocker.Requests;
using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Net.NetworkInformation;

public class Leaderboard : MonoBehaviour
{
    public static Leaderboard instance;

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI leaderboardText;

    [Header("Leaderboard Settings")]
    [SerializeField] private string leaderboardKey = "30044";

    public static Action<LootLockerLeaderboardMember[]> onLeaderboardFetched;

    private Coroutine autoRefreshCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        FetchScores(); // Tự động tải bảng xếp hạng khi game bắt đầu
        autoRefreshCoroutine = StartCoroutine(AutoRefreshLeaderboard());
    }

    IEnumerator AutoRefreshLeaderboard()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            FetchScores(); // Cập nhật mỗi 10 giây
        }
    }

    public void SubmitScore(string memberId, int score)
    {
        StartCoroutine(SubmitScoreCoroutine(memberId, score));
    }

    IEnumerator SubmitScoreCoroutine(string memberId, int score)
    {
        bool done = false;
        string metadataJson = "{\"character\":\"warrior\",\"level\":5}"; // JSON metadata
        LootLockerSDKManager.SubmitScore(memberId, score, leaderboardKey, metadataJson, (response) =>
        {
            if (response.success)
            {
                Debug.Log($"✅ Score {score} submitted successfully for {memberId}");

                // Cập nhật ngay lập tức
                FetchScoresImmediately();
            }
            else
            {
                Debug.LogError($"❌ Failed to submit score for {memberId}. Error: " + response.errorData);
            }
            done = true;
        });

        yield return new WaitUntil(() => done);
    }

    public void FetchScoresImmediately()
    {
        if (autoRefreshCoroutine != null)
        {
            StopCoroutine(autoRefreshCoroutine);
            autoRefreshCoroutine = null;
        }

        if (gameObject.activeInHierarchy)
        {
            FetchScores(); // Cập nhật ngay lập tức
            if (autoRefreshCoroutine == null)
            {
                autoRefreshCoroutine = StartCoroutine(AutoRefreshLeaderboard());
            }
        }
        else
        {
            Debug.LogWarning("Leaderboard is inactive. Skipping fetch.");
        }
    }

    [NaughtyAttributes.Button]
    public void FetchScores()
    {
        StartCoroutine(FetchScoresCoroutine());
    }

    IEnumerator FetchScoresCoroutine()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
        {
            if (response.success)
            {
                LootLockerLeaderboardMember[] members = response.items;

                onLeaderboardFetched?.Invoke(members);

                //// Hiển thị danh sách người chơi
                //leaderboardText.text = "🏆 Leaderboard 🏆\n";
                //for (int i = 0; i < members.Length; i++)
                //{
                //    string playerName = GetPlayerName(members[i]);
                //    leaderboardText.text += $"{i + 1}. {playerName} - {members[i].score} pts\n";
                //}

                done = true;
            }
            else
            {
                Debug.LogError("❌ Failed to fetch leaderboard scores!");
            }
        });

        yield return new WaitUntil(() => done);
    }

    private string GetPlayerName(LootLockerLeaderboardMember member)
    {
        string playerName = $"Player_{member.member_id}";

        if (!string.IsNullOrEmpty(member.player.name))
            playerName = member.player.name;

        return playerName;
    }
}
