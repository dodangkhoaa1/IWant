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
        //animator = GetComponent<Animator>();
    }

    // Allow to greet the user with a localized string
    public void GreetUser()
    {
        localGreeting.Arguments = new object[] { DBManager.fullName };
        localGreeting.StringChanged += UpdateText;
        textGreeting.gameObject.SetActive(true);
    }

    // Allow to update the greeting text
    private void UpdateText(string value)
    {
        textGreeting.text = value;
    }
}
