using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private PencilContainer pencilContainerPrefab;
    [SerializeField] private Transform pencilContainersParent;

    [Header(" Settings ")]
    [SerializeField] private Color[] colors;
    private PencilContainer previousPencilContainer;

    // Allow to initialize the pencil manager
    void Start()
    {
        CreatePencils();
        if (colors.Length > 0)
        {
            PencilContainer firstPencilContainer = pencilContainersParent.GetChild(0).GetComponent<PencilContainer>();
            PencilContainerClickedCallback(firstPencilContainer);

        }
    }

    // Allow to update the pencil manager once per frame
    void Update()
    {

    }

    // Allow to create pencils based on the colors array
    private void CreatePencils()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            CreatePencil(colors[i]);
        }
    }

    // Allow to create a single pencil with a specific color
    private void CreatePencil(Color color)
    {
        PencilContainer pencilContainerInstance = Instantiate(pencilContainerPrefab, pencilContainersParent);
        pencilContainerInstance.Configure(color, this);
    }

    // Allow to handle the pencil container click callback
    internal void PencilContainerClickedCallback(PencilContainer pencilContainer)
    {
        if (previousPencilContainer != null && previousPencilContainer == pencilContainer) return;
        pencilContainer.Select();

        //Unselect previous pencil container
        if (previousPencilContainer != null)
            previousPencilContainer.Unselect();

        previousPencilContainer = pencilContainer;
        GPUSpriteBrush.instance.SetColor(pencilContainer.GetColor());
    }
}
