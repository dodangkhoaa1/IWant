
using LootLocker.Requests;
using UnityEngine;

public class PlayerLeaderboard : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PlayerAuthenticate playerAuthenticate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetBestScoreToLeaderboard();
    }

    //private void SetRandomScore()
    //{
    //    string playerId = playerAuthenticate.PlayerId;
    //    int score = Random.Range(0, 10000);

    //    Leaderboard.instance.SubmitScore(playerId, score);
    //}
    private void SetBestScoreToLeaderboard()
    {
        if (Leaderboard.instance == null)
        {
            Debug.LogError("❌ Leaderboard instance is null!");
            return;
        }

        string playerId = playerAuthenticate.PlayerId;
        int bestScore = ScoreManager.instance.GetBestScore(); // Lấy điểm cao nhất

        Debug.Log($"📢 Đang cập nhật điểm cao nhất: {bestScore} cho PlayerID: {playerId}");

        Leaderboard.instance.SubmitScore(playerId, bestScore);
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
