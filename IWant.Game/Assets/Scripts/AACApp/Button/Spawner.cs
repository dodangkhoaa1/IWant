using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerButton : MonoBehaviour
{
    [SerializeField] GameObject containerButtons;
    [SerializeField] Button ttsButtonPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnTTSButtons();
    }

    public void SpawnTTSButtons()
    {
        var listOfButton = new List<string>();
        listOfButton.Add("Con");
        listOfButton.Add("Không");
        listOfButton.Add("Muốn");
        listOfButton.Add("Ăn");
        listOfButton.Add("Uống");
        listOfButton.Add("Nước");
        foreach (var item in listOfButton)
        {
            Button newTTSBtn = Instantiate(ttsButtonPrefab, containerButtons.transform, false);
            newTTSBtn.GetComponentInChildren<TextMeshProUGUI>().text = item;
        }
        
    }
}
