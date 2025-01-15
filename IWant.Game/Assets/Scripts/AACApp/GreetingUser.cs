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
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    public void GreetUser()
    {
        localGreeting.Arguments = new object[] { DBManager.fullName };
        localGreeting.StringChanged += UpdateText;
        textGreeting.gameObject.SetActive(true);
    }

    private void UpdateText(string value)
    {
        textGreeting.text = value;
    }
}
