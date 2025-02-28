using Newtonsoft.Json;
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
        if (DBManager.User == null || string.IsNullOrEmpty(DBManager.User.FullName))
        {
            Debug.LogError("User or User's FullName is null or empty.");
            return;
        }

        string fullName = DBManager.User.FullName;
        string[] wordInName = fullName.Trim().Split(' ');
        string lastName = wordInName[wordInName.Length - 1];
        localGreeting.Arguments = new object[] { lastName };
        localGreeting.StringChanged += UpdateText;
        localGreeting.RefreshString(); // Ensure the localized string is refreshed
        textGreeting.gameObject.SetActive(true);
    }

    // Allow to update the greeting text
    private void UpdateText(string value)
    {
        textGreeting.text = value;
    }
}
