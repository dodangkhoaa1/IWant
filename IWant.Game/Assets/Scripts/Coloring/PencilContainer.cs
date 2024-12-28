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

    // Start is called before the first frame update
    void Start()
    {
        unSelectedPosition = pencilParent.anchoredPosition;
        selectedPosition = unSelectedPosition + moveMagnitude * Vector2.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            Select();
        else if (Input.GetKeyDown(KeyCode.U))
            Unselect();
    }

    public void Configure(Color color, PencilManager pencilManager)
    {
        this.color = color;
        for (int i = 0; i < imagesToColor.Length; i++)
            imagesToColor[i].color = color;

        this.pencilManager = pencilManager;
    }

    public void ClickedCallback(){
        pencilManager.PencilContainerClickedCallback(this);
    }

    public void Select()
    {
        LeanTween.cancel(pencilParent);
        LeanTween.move(pencilParent, selectedPosition, moveDuration).setEase(LeanTweenType.easeInOutCubic);

    }

    public void Unselect()
    {
        LeanTween.cancel(pencilParent);
        LeanTween.move(pencilParent, unSelectedPosition, moveDuration).setEase(LeanTweenType.easeInOutCubic);

    }

    public Color GetColor() => this.color;
}
