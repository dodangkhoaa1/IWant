using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PencilContainer : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private RectTransform pencilParent;
    [SerializeField] private Image[] imagesToColor;

    [Header(" Settings ")]
    [SerializeField] private float moveMagnitude;
    [SerializeField] private float moveDuration;
    private Vector2 selectedPosition;
    private Vector2 unSelectedPosition;

    private PencilManager pencilManager;
    private Color color;

    // Allow to initialize positions
    void Awake()
    {
        unSelectedPosition = pencilParent.anchoredPosition;
        selectedPosition = unSelectedPosition + moveMagnitude * Vector2.right;
    }

    // Allow to check for input and select/unselect
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Select();
        else if (Input.GetKeyDown(KeyCode.U))
            Unselect();
    }

    // Allow to configure the pencil container
    public void Configure(Color color, PencilManager pencilManager)
    {
        this.color = color;
        for (int i = 0; i < imagesToColor.Length; i++)
            imagesToColor[i].color = color;

        this.pencilManager = pencilManager;
    }

    // Allow to handle click callback
    public void ClickedCallback()
    {
        pencilManager.PencilContainerClickedCallback(this);
    }

    // Allow to select the pencil container
    public void Select()
    {
        LeanTween.cancel(pencilParent);
        LeanTween.move(pencilParent, selectedPosition, moveDuration).setEase(LeanTweenType.easeInOutCubic);
    }

    // Allow to unselect the pencil container
    public void Unselect()
    {
        LeanTween.cancel(pencilParent);
        LeanTween.move(pencilParent, unSelectedPosition, moveDuration).setEase(LeanTweenType.easeInOutCubic);
    }

    // Allow to get the color of the pencil container
    public Color GetColor() => this.color;
}
