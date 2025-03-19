
using LootLocker.Requests;
using UnityEngine;

public class PlayerLeaderboardEmotionGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerAuthenticateEmotionGame playerAuthenticate;
    void Update()
    {

    }
    public void SetBestScoreToLeaderboard()
    {
        if (LeaderboardEmotionGame.instance == null)
        {
            Debug.LogError("❌ Leaderboard instance is null!");
            return;
        }

        string playerId = playerAuthenticate.PlayerId;
        int bestScore = ScoreManagerEmotionGame.instance.GetBestScore();

        Debug.Log($"📢 Đang cập nhật điểm cao nhất: {bestScore} cho PlayerID: {playerId}");

        // Gửi điểm kèm metadata
        LeaderboardEmotionGame.instance.SubmitScoreWithMetadata(playerId, bestScore);
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
