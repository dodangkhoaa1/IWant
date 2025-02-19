using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private BrushData[] brushes;

    // Allow to select a brush by its index
    public void SelectBrush(int index)
    {
        if (index < 0 || index > brushes.Length - 1)
        {
            Debug.Log("Invalid brush index");
            return;
        }

        if (brushes[index] == null)
        {
            Debug.Log("No brush at index: " + index);
            return;
        }
        GPUSpriteBrush.instance.SetBrush(brushes[index]);
    }
}
