using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class GreetingUser : MonoBehaviour
{
    [SerializeField] private LocalizedString localGreeting;
    [SerializeField] private TextMeshProUGUI textGreeting;
    private void Awake()
    {
        // Check if the user is logged in
        if (!DBManager.LoggedIn)
        {
            // If not logged in, load the SignIn scene
            SceneManager.LoadScene(SceneName.SignInScene.ToString());
            return;
        }
    }
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
            Debug.Log("User or User's FullName is null or empty.");
            SceneManager.LoadScene(SceneName.SignInScene.ToString());
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
