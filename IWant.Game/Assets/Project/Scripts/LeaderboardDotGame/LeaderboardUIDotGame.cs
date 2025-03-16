using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardUIDotGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LeaderboardMemberContainerDotGame memberContainerPrefab;
    [SerializeField] private Transform memberContainerParent;

    [SerializeField] private LeaderboardMemberContainerDotGame currentPlayerContainerPrefab; // New prefab for current player
    [SerializeField] private Transform currentPlayerContainerParent; // New transform for current player

    [SerializeField] private PlayerAuthenticateDotGame playerAuthenticate;

    private LeaderboardMemberContainerDotGame currentPlayerContainerInstance; // Reference to the current player's container

    private void Awake()
    {
        LeaderboardDotGame.onLeaderboardFetched += LeaderboardFetchedCallback;
        LeaderboardDotGame.onCurrentPlayerFetched += CurrentPlayerFetchedCallback;
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
        LeaderboardDotGame.onLeaderboardFetched -= LeaderboardFetchedCallback;
        LeaderboardDotGame.onCurrentPlayerFetched -= CurrentPlayerFetchedCallback;
    }

    void OnEnable()
    {
        StartCoroutine(WaitForLeaderboard());
    }

    private IEnumerator WaitForLeaderboard()
    {
        while (LeaderboardDotGame.instance == null)
        {
            Debug.Log("Waiting for Leaderboard instance...");
            yield return null; // Chờ đến frame tiếp theo
        }

        RefreshLeaderboard();
    }
    private void LeaderboardFetchedCallback(LootLockerLeaderboardMember[] members)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (memberContainerParent.childCount <= i)
                CreateMemberContainer(members[i]);
            else
            {
                LeaderboardMemberContainerDotGame container = memberContainerParent.GetChild(i).GetComponent<LeaderboardMemberContainerDotGame>();
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
    private void ConfigureContainer(LeaderboardMemberContainerDotGame container, LootLockerLeaderboardMember member)
    {
        container.Configure(member.rank, GetPlayerName(member), member.score);
    }

    private void CreateMemberContainer(LootLockerLeaderboardMember member)
    {
        LeaderboardMemberContainerDotGame containerInstance = Instantiate(memberContainerPrefab, memberContainerParent);
        ConfigureContainer(containerInstance, member);
    }

    private void CreateCurrentPlayerContainer(LootLockerLeaderboardMember member)
    {
        currentPlayerContainerInstance = Instantiate(currentPlayerContainerPrefab, currentPlayerContainerParent);
        ConfigureContainer(currentPlayerContainerInstance, member);
    }

    private string GetPlayerName(LootLockerLeaderboardMember member)
    {
        string playerName = "Anonymous";
        if ((member.player.name.Length > 0))
        {
            playerName = member.player.name;
        }
        else
        {
            Debug.LogError("Player Name is null");
        }

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
        if (LeaderboardDotGame.instance == null)
        {
            Debug.LogWarning("Leaderboard instance is null, cannot refresh leaderboard.");
            return;
        }

        LeaderboardDotGame.instance.FetchScores();
    }
}
