using UnityEngine;
using LootLocker.Requests;
using System.Collections;
public class PlayerAuthenticate : MonoBehaviour
{
    public string PlayerId { get; private set; }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoginCoroutine());
    }

    IEnumerator LoginCoroutine()
    {
        bool done = false;

        LootLockerSDKManager.StartGuestSession( (response) =>
        {
            if (response.success)
            {
                Debug.Log("Login Successful");
                PlayerId = response.player_id.ToString();
                done = true;
            }
            else
            {
                Debug.Log("Login Failed");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == true);
    }


}
