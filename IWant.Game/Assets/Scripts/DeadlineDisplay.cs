using System;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine;

public class DeadlineDisplay : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private GameObject deadLine;
    [SerializeField] private Transform fruitsParent;
    [SerializeField] private float blinkInterval = 0.5f; // Thời gian giữa các lần nhấp nháy

    private Coroutine blinkCoroutine;

    private void Awake()
    {
        GameManager.onGameStateChanged += GameStateChangedCallback;
    }
    private void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallback;
    }
    void Start()
    {

    }

    void Update()
    {

    }

    private void GameStateChangedCallback(GameState gameState)
    {
        if (gameState == GameState.Game)
        {
            StartCheckingForNearbyFruits();
        }
        else
        {
            StopCheckingForNearbyFruits();
        }
    }

    private void StartCheckingForNearbyFruits()
    {
        StartCoroutine(CheckForNearbyFruitCoroutine());
    }
    private void StopCheckingForNearbyFruits()
    {
        HideDeadline();
        StopCoroutine(CheckForNearbyFruitCoroutine());
    }

    IEnumerator CheckForNearbyFruitCoroutine()
    {
        while (true)
        {
            bool foundNearbyFruit = false;

            for (int i = 0; i < fruitsParent.childCount; i++)
            {
                if (!fruitsParent.GetChild(i).GetComponent<Fruit>().HasCollided())
                    continue;

                float distance = Mathf.Abs(fruitsParent.GetChild(i).position.y - deadLine.transform.position.y);

                if (distance <= 1)
                {
                    StartBlinking();
                    foundNearbyFruit = true;
                    break;
                }
            }
            if (!foundNearbyFruit)
                StopBlinking();

            yield return new WaitForSeconds(1);
        }
    }

    private void StartBlinking()
    {
        if (blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(BlinkCoroutine());
        }
    }

    private void StopBlinking()
    {
        if (blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            deadLine.SetActive(false); // Đảm bảo deadLine tắt khi dừng nhấp nháy
        }
    }

    IEnumerator BlinkCoroutine()
    {
        while (true)
        {
            deadLine.SetActive(!deadLine.activeSelf);
            yield return new WaitForSeconds(blinkInterval);
        }
    }

    private void ShowDeadline() => deadLine.SetActive(true);

    private void HideDeadline() => deadLine.SetActive(false);
}
