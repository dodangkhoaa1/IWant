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
    [SerializeField] private Color selectedColor;
    [SerializeField] private Color unSelectedColor;
    // Start is called before the first frame update
    void Start()
    {
        BrushSizeButtonCallback(0);
    }

    // Update is called once per frame
    void Update()
    {

    }

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
}
