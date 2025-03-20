using LootLocker.Requests;
using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SocialPlatforms.Impl;
using EasyUI.Toast;
using System.Collections.Generic;
using Connect.Core;
using Newtonsoft.Json;

public class LeaderboardDotGame : MonoBehaviour
{
    public static LeaderboardDotGame instance;

    [Header(" Elements ")]
    //[SerializeField] private TMP_InputField playerNameInput; // Ô nhập tên
    //[SerializeField] private Button submitButton;
    [SerializeField] private PlayerLeaderboardDotGame playerLeaderboard;
    [SerializeField] private PlayerAuthenticateDotGame playerAuthenticate;

    [Header("Leaderboard Settings")]
    [SerializeField] public string leaderboardKey;

    public static Action<LootLockerLeaderboardMember[]> onLeaderboardFetched;
    public static Action<LootLockerLeaderboardMember> onCurrentPlayerFetched;

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
        OnSubmitScoreClicked();
        FetchScores();
        autoRefreshCoroutine = StartCoroutine(AutoRefreshLeaderboard());
        //submitButton.onClick.AddListener(OnSubmitButtonClicked);
    }

    IEnumerator AutoRefreshLeaderboard()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            FetchScores();
            OnSubmitScoreClicked();
        }
    }

    private void OnSubmitScoreClicked()//Auto gửi
    {
        int bestScore = ScoreMangerDotGame.instance.GetScore();


        // Assuming member_id is available here
        string playerId = playerAuthenticate.PlayerId; // Replace with actual member_id
        SubmitScoreWithMetadata(playerId, bestScore);

        // Call the method in PlayerLeaderboard to set the best score
        playerLeaderboard.SetBestScoreToLeaderboard();


    }
    public void SubmitScore(string memberId, int score)
    {
        StartCoroutine(SubmitScoreCoroutine(memberId, score));
    }

    IEnumerator SubmitScoreCoroutine(string memberId, int score)
    {
        bool done = false;

        LootLockerSDKManager.SubmitScore(memberId, score, leaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log($"✅ Score {score} submitted successfully for {memberId}");
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

    public void SubmitScoreWithMetadata(string memberId, int score)
    {
        StartCoroutine(SubmitScoreWithMetadataCoroutine(memberId, score));
    }

    private IEnumerator SubmitScoreWithMetadataCoroutine(string memberId, int score)
    {
        bool done = false;

        // Chuyển metadata thành JSON dùng JsonUtility
        string metadataJson = JsonConvert.SerializeObject(
            new DotGameData(
                DBManager.User, 
                PlayerPrefs.GetInt("CurrentStage", 1), 
                PlayerPrefs.GetInt("CurrentLevel", 1))
            );

        LootLockerSDKManager.SubmitScore(memberId, score, leaderboardKey, metadataJson, (response) =>
        {
            if (response.success)
            {
                Debug.Log($"✅ Score {score} submitted successfully for {memberId} with metadata: {metadataJson}");

                // Cập nhật ngay leaderboard
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
            FetchScores();
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

    //IEnumerator FetchScoresCoroutine()
    //{
    //    bool done = false;
    //    LootLockerSDKManager.GetScoreList(leaderboardKey, 10, (response) =>
    //    {
    //        if (response.success)
    //        {
    //            LootLockerLeaderboardMember[] members = response.items;
    //            ProcessScores(members);
    //            //onLeaderboardFetched?.Invoke(members);
    //            done = true;
    //        }
    //        else
    //        {
    //            Debug.LogError("❌ Failed to fetch leaderboard scores!");
    //        }
    //    });

    //    yield return new WaitUntil(() => done);
    //}
    public IEnumerator FetchScoresCoroutine()
    {
        int? cursor = null;
        List<LootLockerLeaderboardMember> allScores = new List<LootLockerLeaderboardMember>();

        do
        {
            bool done = false; // Đặt ở đây để reset cho mỗi lần gọi API

            LootLockerSDKManager.GetScoreList(leaderboardKey, 50, cursor ?? 0, (response) =>
            {
                if (response.success)
                {
                    allScores.AddRange(response.items); // Thêm điểm số vào danh sách

                    if (response.pagination != null)
                        cursor = response.pagination.next_cursor; // Lấy cursor tiếp theo
                    else
                        cursor = null; // Nếu không có pagination, dừng lặp

                }
                else
                {
                    Debug.LogError("❌ Failed to fetch leaderboard scores!");
                    cursor = null; // Dừng lặp nếu lỗi xảy ra
                }

                done = true; // Đánh dấu đã xong
            });

            yield return new WaitUntil(() => done);

        } while (cursor.HasValue && cursor != 0); // Kiểm tra cursor hợp lệ

        // Gọi hàm xử lý điểm số sau khi lấy hết
        ProcessScores(allScores.ToArray());
    }




    private void ProcessScores(LootLockerLeaderboardMember[] members)
    {
        List<LootLockerLeaderboardMember> top5 = new List<LootLockerLeaderboardMember>();
        LootLockerLeaderboardMember currentPlayer = null;

        for (int i = 0; i < members.Length; i++)
        {
            if (i < 5)
            {
                top5.Add(members[i]);
            }

            if (members[i].member_id == playerAuthenticate.PlayerId)
            {
                currentPlayer = members[i];
            }
        }

        // Update the display name to use User.FullName from metadata
        foreach (var member in top5)
        {
            DotGameData dotGameData = JsonConvert.DeserializeObject<DotGameData>(member.metadata);
            UserResponseDTO user = dotGameData.User;
            if (user != null)
            {
                member.player.name = DBManager.GetDisplayName(user);
            }
        }

        onLeaderboardFetched?.Invoke(top5.ToArray());

        // Nếu currentPlayer có trong top5 thì gọi luôn sự kiện hiển thị
        if (currentPlayer != null)
        {
            DotGameData currentdotGameData = JsonConvert.DeserializeObject<DotGameData>(currentPlayer.metadata);
            UserResponseDTO currentUser = currentdotGameData.User;
            if (currentUser != null)
            {
                currentPlayer.player.name = DBManager.GetDisplayName(currentUser);
                PlayerPrefs.SetInt("CurrentStage", currentdotGameData.CurrentStage);
                PlayerPrefs.SetInt("CurrentLevel", currentdotGameData.CurrentLevel);
                PlayerPrefs.SetInt("HighScoreDotGame", currentdotGameData.CurrentLevel);//set diem lon nhat

            }
            onCurrentPlayerFetched?.Invoke(currentPlayer);
        }
    }

    [Serializable]
    public class DotGameData
    {
        public UserResponseDTO User { get; set; }
        public int CurrentStage { get; set; }
        public int CurrentLevel { get; set; }

        public DotGameData(UserResponseDTO user, int currentStage, int currentLevel)
        {
            User = user;
            CurrentStage = currentStage;
            CurrentLevel = currentLevel;
        }
    }

}
