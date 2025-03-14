using Connect.Core;
using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeaderboardDotGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerAuthenticateDotGame playerAuthenticate;
    void Update()
    {

    }
    public void SetBestScoreToLeaderboard(string userId)
    {
        if (LeaderboardDotGame.instance == null)
        {
            Debug.LogError("❌ Leaderboard instance is null!");
            return;
        }

        string playerId = playerAuthenticate.PlayerId;
        int bestScore = ScoreMangerDotGame.instance.GetScore();

        Debug.Log($"📢 Đang cập nhật điểm cao nhất: {bestScore} cho PlayerID: {playerId}, UserID: {userId}");

        // Gửi điểm kèm metadata
        LeaderboardDotGame.instance.SubmitScoreWithMetadata(playerId, bestScore, userId);
    }

    public void SetPlayerName(string playerName)
    {
        LootLockerSDKManager.SetPlayerName(playerName, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Player Name has been Set: " + playerName);
            }
            else
            {
                Debug.Log("Error setting the player name...");
            }
        });
    }

}
