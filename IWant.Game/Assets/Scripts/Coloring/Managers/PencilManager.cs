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

    // Start is called before the first frame update
    void Start()
    {
        CreatePencils();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreatePencils()
    {
        for (int i = 0; i < colors.Length; i++)
        {
            CreatePencil(colors[i]);
        }
    }

    private void CreatePencil(Color color)
    {
        PencilContainer pencilContainerInstance = Instantiate(pencilContainerPrefab, pencilContainersParent);
        pencilContainerInstance.Configure(color, this);
    }

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
