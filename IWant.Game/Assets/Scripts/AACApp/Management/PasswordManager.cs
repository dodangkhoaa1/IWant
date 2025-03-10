using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordManager : MonoBehaviour
{
    [Header(" Sprites ")]
    [SerializeField] private Sprite showPasswordSprite;
    [SerializeField] private Sprite hidePasswordSprite;

    [Header(" Elements ")]
    [SerializeField] private Button toggleButton;

    private TMP_InputField passwordField;
    private Image toggleImage;

    private bool isPasswordVisible { get; set; }

    // Allow to initialize the password manager
    void Start()
    {
        passwordField = gameObject.GetComponent<TMP_InputField>();
        isPasswordVisible = false;
        passwordField.contentType = TMP_InputField.ContentType.Password;
        toggleImage = toggleButton.GetComponent<Image>();
        toggleImage.sprite = showPasswordSprite;
    }

    // Allow to toggle the visibility of the password
    public void TogglePasswordVisible()
    {
        //Change the state of password visibility
        isPasswordVisible = !isPasswordVisible;

        //Change visible of input field
        passwordField.contentType = isPasswordVisible ? TMP_InputField.ContentType.Standard : TMP_InputField.ContentType.Password;
        passwordField.ForceLabelUpdate();

        toggleImage.sprite = isPasswordVisible ? hidePasswordSprite : showPasswordSprite;
    }
}
