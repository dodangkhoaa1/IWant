using LootLocker.Requests;
using System.Collections;
using System.ComponentModel;
using UnityEngine;

public class LeaderboardUIEmotionGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LeaderboardMemberContainerEmotionGame memberContainerPrefab;
    [SerializeField] private Transform memberContainerParent;

    [SerializeField] private LeaderboardMemberContainerEmotionGame currentPlayerContainerPrefab; // New prefab for current player
    [SerializeField] private Transform currentPlayerContainerParent; // New transform for current player

    [SerializeField] private PlayerAuthenticateEmotionGame playerAuthenticate;

    private LeaderboardMemberContainerEmotionGame currentPlayerContainerInstance; // Reference to the current player's container

    private void Awake()
    {
        LeaderboardEmotionGame.onLeaderboardFetched += LeaderboardFetchedCallback;
        LeaderboardEmotionGame.onCurrentPlayerFetched += CurrentPlayerFetchedCallback;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        LeaderboardEmotionGame.onLeaderboardFetched -= LeaderboardFetchedCallback;
        LeaderboardEmotionGame.onCurrentPlayerFetched -= CurrentPlayerFetchedCallback;
    }

    void OnEnable()
    {
        StartCoroutine(WaitForLeaderboard());
    }

    private IEnumerator WaitForLeaderboard()
    {
        while (LeaderboardEmotionGame.instance == null)
        {
            Debug.Log("Waiting for Leaderboard instance...");
            yield return null; // Chờ đến frame tiếp theo
        }

        RefreshLeaderboard();
    }

    //private void LeaderboardFetchedCallback(LootLockerLeaderboardMember[] members)
    //{
    //    for (int i = 0; i < members.Length; i++)
    //    {
    //        if (memberContainerParent.childCount <= i)
    //            CreateMemberContainer(members[i]);
    //        else
    //        {
    //            LeaderboardMemberContainerEmotionGame container = memberContainerParent.GetChild(i).GetComponent<LeaderboardMemberContainerEmotionGame>();
    //            ConfigureContainer(container, members[i]);
    //        }

    //        // Check if the current member is the current player
    //        if (IsCurrentPlayer(members[i]))
    //        {
    //            if (currentPlayerContainerInstance == null)
    //            {
    //                CreateCurrentPlayerContainer(members[i]);
    //            }
    //            else
    //            {
    //                ConfigureContainer(currentPlayerContainerInstance, members[i]);
    //            }
    //        }
    //    }

    //    // Remove the excess
    //    while (memberContainerParent.childCount > members.Length)
    //    {
    //        Transform t = memberContainerParent.GetChild(memberContainerParent.childCount - 1);
    //        t.SetParent(null);
    //        Destroy(t.gameObject);
    //    }
    //}
    private void LeaderboardFetchedCallback(LootLockerLeaderboardMember[] members)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (memberContainerParent.childCount <= i)
                CreateMemberContainer(members[i]);
            else
            {
                LeaderboardMemberContainerEmotionGame container = memberContainerParent.GetChild(i).GetComponent<LeaderboardMemberContainerEmotionGame>();
                ConfigureContainer(container, members[i]);
            }
        }

        // Remove the excess
        while (memberContainerParent.childCount > members.Length)
        {
            Transform t = memberContainerParent.GetChild(memberContainerParent.childCount - 1);
            t.SetParent(null);
            Destroy(t.gameObject);
        }
    }
    //moi them
    private void CurrentPlayerFetchedCallback(LootLockerLeaderboardMember member)
    {
        if (currentPlayerContainerInstance == null)
        {
            CreateCurrentPlayerContainer(member);
        }
        else
        {
            ConfigureContainer(currentPlayerContainerInstance, member);
        }
    }
    private void ConfigureContainer(LeaderboardMemberContainerEmotionGame container, LootLockerLeaderboardMember member)
    {
        container.Configure(member.rank, GetPlayerName(member), member.score);
    }

    private void CreateMemberContainer(LootLockerLeaderboardMember member)
    {
        LeaderboardMemberContainerEmotionGame containerInstance = Instantiate(memberContainerPrefab, memberContainerParent);
        ConfigureContainer(containerInstance, member);
    }

    private void CreateCurrentPlayerContainer(LootLockerLeaderboardMember member)
    {
        currentPlayerContainerInstance = Instantiate(currentPlayerContainerPrefab, currentPlayerContainerParent);
        ConfigureContainer(currentPlayerContainerInstance, member);
    }

    private string GetPlayerName(LootLockerLeaderboardMember member)
    {
        string playerName = "Player_" + member.member_id;

        if ((member.player.name.Length > 0))
            playerName = member.player.name;

        return playerName;
    }

    private bool IsCurrentPlayer(LootLockerLeaderboardMember member)
    {
        // Replace with actual logic to determine if the member is the current player
        return member.member_id == playerAuthenticate.PlayerId;
    }

    // Method to refresh the leaderboard data
    void RefreshLeaderboard()
    {
        if (LeaderboardEmotionGame.instance == null)
        {
            Debug.LogWarning("Leaderboard instance is null, cannot refresh leaderboard.");
            return;
        }

        LeaderboardEmotionGame.instance.FetchScores();
    }
}


