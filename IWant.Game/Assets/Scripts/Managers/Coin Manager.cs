using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager instance;

    [Header(" Variables ")]
    private int coins;
    private const string coinsKey = "Coins";

    [Header(" Actions ")]
    public static Action onCoinsUpdated;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
     
        }
        else
        {
            Destroy(gameObject);
        }
        LoadData();

        UpdateCoinTexts();

        MergeManager.onMergeProcess += MergeProcessedCallback;
    }
    private void OnDestroy()
    {
        MergeManager.onMergeProcess -= MergeProcessedCallback;
    }

    private void MergeProcessedCallback(FruitType fruitType, Vector2 fruitSpawnPos)
    {
        int coinsToAdd = (int)fruitType;

        AddCoins(coinsToAdd);
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        coins = Mathf.Max(0, coins);

        SaveData();

        UpdateCoinTexts();

    }

    private void UpdateCoinTexts()
    {
      CoinText[] coinTexts = Resources.FindObjectsOfTypeAll(typeof(CoinText)) as CoinText[];

        for (int i = 0; i < coinTexts.Length; i++)
            coinTexts[i].UpdateText(coins.ToString());

        onCoinsUpdated?.Invoke();
    }

    public bool CanPurchase(int price)
    {
      return coins >= price;
    }

    private void LoadData() => coins = PlayerPrefs.GetInt(coinsKey,0);

    private void SaveData() => PlayerPrefs.SetInt(coinsKey, coins);

}
