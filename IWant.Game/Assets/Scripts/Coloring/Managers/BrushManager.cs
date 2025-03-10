using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrushManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private BrushData[] brushes;
    [SerializeField] private Button[] brushButtons; // Add reference to the buttons

    private int selectedBrushIndex = -1;

    void Start()
    {
        // Load the saved brush index
        selectedBrushIndex = PlayerPrefs.GetInt("SelectedBrushIndex", 0);
        SelectBrush(selectedBrushIndex);
    }

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

        UpdateUIScale(index);

        // Save the selected brush index
        PlayerPrefs.SetInt("SelectedBrushIndex", index);
        PlayerPrefs.Save();
    }

    private void UpdateUIScale(int index)
    {
        // Update button scales
        for (int i = 0; i < brushButtons.Length; i++)
        {
            if (i == index)
            {
                brushButtons[i].transform.localScale = new Vector3(1.25f, 1.25f, 1);
            }
            else
            {
                brushButtons[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
