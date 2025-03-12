
using LootLocker.Requests;
using UnityEngine;

public class PlayerLeaderboard : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerAuthenticate playerAuthenticate;
    void Update()
    {

    }
    public void SetBestScoreToLeaderboard(string userId)
    {
        if (LeaderboardEmotionGame.instance == null)
        {
            Debug.LogError("❌ Leaderboard instance is null!");
            return;
        }

        string playerId = playerAuthenticate.PlayerId;
        int bestScore = ScoreManager.instance.GetBestScore();

        Debug.Log($"📢 Đang cập nhật điểm cao nhất: {bestScore} cho PlayerID: {playerId}, UserID: {userId}");

        // Gửi điểm kèm metadata
        Leaderboard.instance.SubmitScoreWithMetadata(playerId, bestScore, userId);
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
