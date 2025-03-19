using UnityEngine;
using LootLocker.Requests;
using System.Collections;
using System;


public class PlayerAuthenticateDotGame : MonoBehaviour
{
    public static event Action OnLoginSuccess; // Sự kiện báo đăng nhập thành công
    public string PlayerId { get; private set; }

    void Start()
    {
        StartCoroutine(LoginCoroutine());
    }

    IEnumerator LoginCoroutine()
    {
        bool isDone = false;

        LootLockerSDKManager.StartGuestSession(DBManager.User.UserId, (response) =>
        {
            if (response.success)
            {
                Debug.Log("✅ Đăng nhập thành công!");
                PlayerId = response.player_id.ToString();
                isDone = true;

                // Gửi sự kiện để thông báo rằng LootLocker đã sẵn sàng
                OnLoginSuccess?.Invoke();
            }
            else
            {
                Debug.LogError("❌ Đăng nhập thất bại! Kiểm tra API Key của LootLocker.");
                isDone = true;
            }
        });

        yield return new WaitUntil(() => isDone);
    }
}
