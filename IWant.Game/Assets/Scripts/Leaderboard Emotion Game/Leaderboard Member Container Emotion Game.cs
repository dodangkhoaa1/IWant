using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;
public class LeaderboardMemberContainerEmotionGame : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image rankContainer;
    [SerializeField] private TextMeshProUGUI rankText;
    [SerializeField] private TextMeshProUGUI playerNameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    [Header(" Colors ")]
    private Color gold = new Color(1, 0.84f, 0);
    private Color silver = new Color(0.75f, 0.75f, 0.75f);
    private Color bronze = new Color(0.8f, 0.52f, 0.25f);

    public void Configure(int rank, string playerName, int score)
    {
        rankContainer.color = GetRankColor(rank);
        rankText.text = rank.ToString();

        playerNameText.text = playerName;
        scoreText.text = score.ToString();

    }

    private Color GetRankColor(int rank)
    {
        switch (rank)
        {
            case 1:
                return gold;
            case 2:
                return silver;
            case 3:
                return bronze;

            default:
                return Color.gray;
        }
    }
}
