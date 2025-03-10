using LootLocker.Requests;
using System.ComponentModel;
using UnityEngine;

public class LeaderboardUI : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private LeaderboardMemberContainer memberContainerPrefab;
    [SerializeField] private Transform memberContainerParent;

    private void Awake()
    {
        Leaderboard.onLeaderboardFetched += LeaderboardFetchedCallback;
    }

    private void OnDestroy()
    {
        Leaderboard.onLeaderboardFetched -= LeaderboardFetchedCallback;

    }

    private void LeaderboardFetchedCallback(LootLockerLeaderboardMember[] members)
    {
        for (int i = 0; i < members.Length; i++)
        {
            if (memberContainerParent.childCount <= i)
                CreateMemberContainer(members[i]);
            else
            {
                LeaderboardMemberContainer container = memberContainerParent.GetChild(i).GetComponent<LeaderboardMemberContainer>();
                ConfigureContainer(container, members[i]);
            }
              
        }

       
        //Remove the excexx
        while (memberContainerParent.childCount > members.Length)
        {
            Transform t = memberContainerParent.GetChild(memberContainerParent.childCount - 1);
            t.SetParent(null);
            Destroy(t.gameObject);

        }
       
    }
  private void ConfigureContainer(LeaderboardMemberContainer container, LootLockerLeaderboardMember member)
    {
        container.Configure(member.rank, GetPlayerName(member), member.score);
    }
    private void CreateMemberContainer(LootLockerLeaderboardMember member)
    {
        LeaderboardMemberContainer containerInstance = Instantiate(memberContainerPrefab, memberContainerParent);
        ConfigureContainer(containerInstance, member);
    }


  

    private string GetPlayerName(LootLockerLeaderboardMember member)
    {


        string playerName = "Player_" + member.member_id;

        if ((member.player.name.Length > 0))
            playerName = member.player.name;

        return playerName;
    }

}
