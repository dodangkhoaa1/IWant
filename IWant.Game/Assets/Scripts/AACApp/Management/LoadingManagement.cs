using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManagement : MonoBehaviour
{
    public GameObject loadingPanelPrefab;

    private GameObject loadingPanelInstance;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        if (canvas != null && loadingPanelPrefab != null)
        {
            loadingPanelInstance = Instantiate(loadingPanelPrefab, canvas.transform);
            loadingPanelInstance.SetActive(false); // Initially set to inactive
        }
    }

    public void EnableLoadingPanel()
    {
        if (loadingPanelInstance != null)
        {
            loadingPanelInstance.SetActive(true);
        }
    }
    public void DisableLoadingPanel()
    {
        if (loadingPanelInstance != null)
        {
            loadingPanelInstance.SetActive(false);
        }
    }
}
