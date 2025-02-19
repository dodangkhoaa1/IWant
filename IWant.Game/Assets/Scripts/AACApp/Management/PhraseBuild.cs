using EasyUI.Toast;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// Manages a dynamic list of draggable buttons, allowing users to rearrange them by dragging.
/// Supports adding, removing, and playing a sequence of buttons.
/// </summary>
public class PhraseBuild : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float transitionTime = 0.5f;
    [SerializeField] private int MAX_BUTTON_COUNT = 5; // Max number of buttons allowed in phraseContainer

    [Header("UI Elements")]
    [SerializeField] private RectTransform phraseContainer; // Container holding the phrase buttons
    [SerializeField] private Transform aacButtonContainer; // Container for AAC buttons
    [SerializeField] private Button deleteBtn; // Button to delete the last button
    [SerializeField] private Button playBtn; // Button to play the sequence of buttons

    private Dictionary<int, Vector2> buttonInitialPositions = new Dictionary<int, Vector2>(); // Stores initial positions of buttons
    private bool isSwapping = false; // Cờ kiểm soát đổi chỗ
    private GameObject currentSwapTarget = null; // Track the current swap target

    private void Start()
    {
        StartCoroutine(UpdateUIToolBarButtons());
        InitializeButtonPositions();

        deleteBtn.onClick.AddListener(() => RemoveAllChildren());
        playBtn.onClick.AddListener(() => PlayPhrase());
    }

    /// <summary>
    /// Allow to initialize the positions of all buttons in the container.
    /// </summary>
    private void InitializeButtonPositions()
    {
        for (int i = 0; i < phraseContainer.childCount; i++)
        {
            RectTransform buttonRect = phraseContainer.GetChild(i).GetComponent<RectTransform>();
            Vector2 initialPosition = CalculateButtonPosition(i);
            buttonRect.anchoredPosition = initialPosition;
            buttonInitialPositions[buttonRect.GetInstanceID()] = initialPosition;
        }
    }

    /// <summary>
    /// Allow to add a button to the phrase container.
    /// </summary>
    public void AddToList(GameObject wordButton)
    {
        if (phraseContainer.childCount >= MAX_BUTTON_COUNT)
        {
            Toast.Show("Phrase container can only hold up to 5 buttons.", Color.red, ToastPosition.BottomCenter);
            return;
        }
        GameObject wordButtonInstance = Instantiate(wordButton, phraseContainer.transform);
        wordButtonInstance.tag = "PhraseWord";
        RectTransform instanceRect = wordButtonInstance.GetComponent<RectTransform>();
        instanceRect.sizeDelta = wordButton.GetComponent<RectTransform>().sizeDelta;
        instanceRect.localScale = wordButton.GetComponent<RectTransform>().localScale;

        AddDragEvent(wordButtonInstance);

        Vector2 initialPosition = CalculateButtonPosition(phraseContainer.childCount - 1);
        instanceRect.anchoredPosition = initialPosition;
        buttonInitialPositions[wordButtonInstance.GetInstanceID()] = initialPosition;

        // Disable interaction of the original button in aacButtonContainer
        Button sourceButton = wordButton.GetComponent<Button>();
        if (sourceButton != null)
        {
            sourceButton.interactable = false;
        }

        StartCoroutine(UpdateUIToolBarButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Allow to clear all buttons from the phrase container.
    /// </summary>
    public void RemoveAllChildren()
    {
        foreach (Transform child in phraseContainer)
        {
            EnableInteractionOfButton(child.gameObject.GetComponent<Button>());
            Destroy(child.gameObject);
        }
        StartCoroutine(UpdateUIToolBarButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Allow to remove a specific button from the phrase container.
    /// </summary>
    public IEnumerator RemoveFromList(GameObject aacWordGO)
    {
        EnableInteractionOfButton(aacWordGO.GetComponent<Button>());
        Destroy(aacWordGO.gameObject);
        yield return null;
        buttonInitialPositions.Remove(aacWordGO.GetInstanceID());
        StartCoroutine(UpdateUIToolBarButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Allow to play the sequence of buttons with audio feedback.
    /// </summary>
    public void PlayPhrase()
    {
        StartCoroutine(PlayPhraseCoroutine());
    }

    private IEnumerator PlayPhraseCoroutine()
    {
        foreach (Transform child in phraseContainer)
        {
            TextToSpeech tts = child.GetComponent<TextToSpeech>();
            if (tts != null)
            {
                yield return StartCoroutine(tts.CallTextToSpeechCoroutine());
            }
        }
    }

    /// <summary>
    /// Allow to update the UI toolbar buttons.
    /// </summary>
    private IEnumerator UpdateUIToolBarButtons()
    {
        yield return null;
        bool hasChildren = phraseContainer.childCount > 0;
        deleteBtn.interactable = hasChildren;
        playBtn.interactable = hasChildren;
    }

    /// <summary>
    /// Allow to update the positions of all buttons in the container.
    /// </summary>
    private void UpdateButtonPositions()
    {
        Debug.Log("UpdateButtonPositions");

        for (int i = 0; i < phraseContainer.childCount; i++)
        {
            RectTransform buttonRect = phraseContainer.GetChild(i).GetComponent<RectTransform>();
            Vector2 position = CalculateButtonPosition(i);
            LeanTween.moveLocal(buttonRect.gameObject, position, transitionTime).setEase(LeanTweenType.easeOutQuad);
            buttonInitialPositions[buttonRect.gameObject.GetInstanceID()] = position;
        }
    }

    /// <summary>
    /// Allow to calculate the position of a button based on its index.
    /// </summary>
    private Vector2 CalculateButtonPosition(int index)
    {
        return new Vector2(175 + index * (350 + 50), -200);
    }

    /// <summary>
    /// Allow to add drag events to a button.
    /// </summary>
    private void AddDragEvent(GameObject button)
    {
        EventTrigger trigger = button.GetComponent<EventTrigger>() ?? button.AddComponent<EventTrigger>();

        EventTrigger.Entry dragEntry = new EventTrigger.Entry { eventID = EventTriggerType.Drag };
        dragEntry.callback.AddListener((data) => { OnDrag((PointerEventData)data, button); });
        trigger.triggers.Add(dragEntry);

        EventTrigger.Entry endDragEntry = new EventTrigger.Entry { eventID = EventTriggerType.EndDrag };
        endDragEntry.callback.AddListener((data) => { OnEndDrag((PointerEventData)data, button); });
        trigger.triggers.Add(endDragEntry);
    }

    /// <summary>
    /// Allow to handle the drag event of a button.
    /// </summary>
    private void OnDrag(PointerEventData data, GameObject button)
    {
        RectTransform buttonRect = button.GetComponent<RectTransform>();
        RectTransform parentRect = (RectTransform)phraseContainer.transform;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRect, data.position, data.pressEventCamera, out Vector2 localPointerPosition))
        {
            buttonRect.localPosition = localPointerPosition;
        }

        if (isSwapping) return;

        Collider2D[] colliders = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(data.position));
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("PhraseWord") && collider.gameObject != button)
            {
                GameObject anotherButton = collider.gameObject;

                // Check if we've already swapped with this button
                if (currentSwapTarget == anotherButton) continue;

                currentSwapTarget = anotherButton; // Mark this as the current swap target

                isSwapping = true;

                button.GetComponent<Collider2D>().enabled = false;
                anotherButton.GetComponent<Collider2D>().enabled = false;

                StartCoroutine(EnableColliders(button, anotherButton));

                // Swap positions
                Vector2 currentButtonPosition = buttonInitialPositions[button.GetInstanceID()];
                Vector2 anotherButtonPosition = buttonInitialPositions[anotherButton.GetInstanceID()];

                LeanTween.moveLocal(anotherButton, currentButtonPosition, transitionTime).setEase(LeanTweenType.easeOutQuad);

                // Swap sibling indexes
                int buttonIndex = button.transform.GetSiblingIndex();
                int anotherButtonIndex = anotherButton.transform.GetSiblingIndex();

                button.transform.SetSiblingIndex(anotherButtonIndex);
                anotherButton.transform.SetSiblingIndex(buttonIndex);

                // Update positions in the dictionary
                buttonInitialPositions[button.GetInstanceID()] = anotherButtonPosition;
                buttonInitialPositions[anotherButton.GetInstanceID()] = currentButtonPosition;

                Debug.Log($"Swapped {button.name} with {anotherButton.name}");
                StartCoroutine(ResetSwapFlag());
                break;
            }
        }
    }

    /// <summary>
    /// Allow to reset the swap flag after a delay.
    /// </summary>
    private IEnumerator ResetSwapFlag()
    {
        yield return new WaitForSeconds(transitionTime); // Wait to avoid instant re-triggering
        isSwapping = false;
        currentSwapTarget = null; // Reset the current swap target
    }

    /// <summary>
    /// Allow to enable the colliders of two buttons after a delay.
    /// </summary>
    private IEnumerator EnableColliders(GameObject button, GameObject anotherButton)
    {
        yield return new WaitForSeconds(transitionTime);
        button.GetComponent<Collider2D>().enabled = true;
        anotherButton.GetComponent<Collider2D>().enabled = true;
        isSwapping = false;
    }

    /// <summary>
    /// Allow to handle the end drag event of a button.
    /// </summary>
    private void OnEndDrag(PointerEventData data, GameObject button)
    {
        if (data.position.y < Screen.height * 0.5f)
        {
            StartCoroutine(RemoveFromList(button));
        }
        else
        {
            UpdateButtonPositions();
        }
    }

    /// <summary>
    /// Allow to enable interaction of the original button in aacButtonContainer.
    /// </summary>
    private void EnableInteractionOfButton(Button button)
    {
        // Enable interaction of the original button in aacButtonContainer
        string originalButtonName = button.name.Replace("(Clone)", "").Trim();
        Debug.Log(originalButtonName);
        foreach (Transform child in aacButtonContainer)
        {
            if (child.name == originalButtonName)
            {
                Button sourceButton = child.GetComponent<Button>();
                if (sourceButton != null)
                {
                    sourceButton.interactable = true;
                }
                break;
            }
        }
    }
}
