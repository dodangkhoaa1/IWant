using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class GreetingUser : MonoBehaviour
{
    [SerializeField] private LocalizedString localGreeting;
    [SerializeField] private TextMeshProUGUI textGreeting;
    
    // Start is called before the first frame update
    void Start()
    {
        localGreeting.Arguments = new object[] { DBManager.fullName };
        localGreeting.StringChanged += UpdateText; 
    }

    private void UpdateText(string value)
    {
        textGreeting.text = value;
    }
}
