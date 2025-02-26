﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class PowerupManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Button blastButton;
    [SerializeField] private Image hideBlastContainer;

    [Header(" Settings ")]
    [SerializeField] private int blastPrice;

    private void Awake()
    {
        CoinManager.onCoinsUpdated += CoinsUpdatedCallback;
    }

    private void Start()
    {
        ManageBlastButtonInteractability(); // Cập nhật UI khi khởi động game
    }

    private void OnDestroy()
    {
        CoinManager.onCoinsUpdated -= CoinsUpdatedCallback;
    }

    public void BlastButtonCallback()
    {
        Debug.Log("Boom!!");

        Fruit[] smallFruits = FruitManager.instance.GetSmallFruits();

        if (smallFruits.Length <= 0)
            return;

        for (int i = 0; i < smallFruits.Length; i++)
            smallFruits[i].Merge();

        CoinManager.instance.AddCoins(-blastPrice);
    }

    private void ManageBlastButtonInteractability()
    {
        bool canBlast = CoinManager.instance.CanPurchase(blastPrice);
        blastButton.interactable = canBlast;
        hideBlastContainer.gameObject.SetActive(!canBlast); // Hiển thị hoặc ẩn hideBlastContainer
    }

    private void CoinsUpdatedCallback()
    {
        ManageBlastButtonInteractability();
    }
}
