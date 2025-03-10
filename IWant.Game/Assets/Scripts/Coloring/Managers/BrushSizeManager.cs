using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushSizeManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image[] brushImages;

    [Header(" Settings ")]
    [SerializeField] private float[] brushSizes;
    public Color selectedColor;
    [SerializeField] private Color unSelectedColor;

    // Allow to initialize the brush size manager
    void Start()
    {
        BrushSizeButtonCallback(0);
    }

    // Allow to update the brush size manager each frame
    void Update()
    {
    }

    // Allow to handle brush size button click
    public void BrushSizeButtonCallback(int sizeIndex)
    {
        if (sizeIndex > brushSizes.Length - 1)
        {
            Debug.LogError("Brush Size not Found");
            return;
        }

        float targetBrushSize = brushSizes[sizeIndex];
        GPUSpriteBrush.instance.SetBrushSize(targetBrushSize);

        //Color the current brush size button
        for (int i = 0; i < brushImages.Length; i++)
            brushImages[i].color = (i == sizeIndex) ? selectedColor : unSelectedColor;
    }

    // Allow to update the color of the selected brush
    internal void UpdateSelectedBrushColor(Color color)
    {
        for (int i = 0; i < brushImages.Length; i++)
        {
            if (brushImages[i].color != unSelectedColor)
            {
                brushImages[i].color = color;
            }
        }
    }
}
