using System.Collections;
using System.Collections.Generic;
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

    [Header("UI Elements")]
    [SerializeField] private RectTransform phraseContainer; // Container holding the phrase buttons
    [SerializeField] private Button deleteBtn; // Button to delete the last button
    [SerializeField] private Button playBtn; // Button to play the sequence of buttons

    private AudioSource audioSource;
    private Dictionary<int, Vector2> buttonInitialPositions = new Dictionary<int, Vector2>(); // Stores initial positions of buttons
    private bool isSwapping = false; // Cờ kiểm soát đổi chỗ
    private GameObject currentSwapTarget = null; // Track the current swap target

    private void Start()
    {
        audioSource = AudioManager.Instance.GetComponent<AudioSource>();
        StartCoroutine(UpdateUIButtons());
        InitializeButtonPositions();

        deleteBtn.onClick.AddListener(() => RemoveAllChildren());
        playBtn.onClick.AddListener(() => PlayPhrase());
    }

    /// <summary>
    /// Initializes the positions of all buttons in the container.
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
    /// Adds a button to the phrase container.
    /// </summary>
    public void AddToList(GameObject wordButton)
    {
        GameObject wordButtonInstance = Instantiate(wordButton, phraseContainer.transform);
        wordButtonInstance.tag = "PhraseWord";
        RectTransform instanceRect = wordButtonInstance.GetComponent<RectTransform>();
        instanceRect.sizeDelta = wordButton.GetComponent<RectTransform>().sizeDelta;
        instanceRect.localScale = wordButton.GetComponent<RectTransform>().localScale;

        AddDragEvent(wordButtonInstance);

        Vector2 initialPosition = CalculateButtonPosition(phraseContainer.childCount - 1);
        instanceRect.anchoredPosition = initialPosition;
        buttonInitialPositions[wordButtonInstance.GetInstanceID()] = initialPosition;

        StartCoroutine(UpdateUIButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Clears all buttons from the phrase container.
    /// </summary>
    public void RemoveAllChildren()
    {
        foreach (Transform child in phraseContainer)
        {
            Destroy(child.gameObject);
        }
        StartCoroutine(UpdateUIButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Removes a specific button from the phrase container.
    /// </summary>
    public void RemoveFromList(GameObject button)
    {
        Destroy(button);
        buttonInitialPositions.Remove(button.GetInstanceID());
        StartCoroutine(UpdateUIButtons());
        UpdateButtonPositions();
    }

    /// <summary>
    /// Plays the sequence of buttons with audio feedback.
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

    private IEnumerator UpdateUIButtons()
    {
        yield return null;
        bool hasChildren = phraseContainer.childCount > 0;
        deleteBtn.interactable = hasChildren;
        playBtn.interactable = hasChildren;
    }

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


    private Vector2 CalculateButtonPosition(int index)
    {
        return new Vector2(175 + index * (350 + 50), -200);
    }

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

                //LeanTween.moveLocal(button, anotherButtonPosition, transitionTime).setEase(LeanTweenType.easeOutQuad);
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

    private IEnumerator ResetSwapFlag()
    {
        yield return new WaitForSeconds(transitionTime); // Wait to avoid instant re-triggering
        isSwapping = false;
        currentSwapTarget = null; // Reset the current swap target
    }
    private IEnumerator EnableColliders(GameObject button, GameObject anotherButton)
    {
        yield return new WaitForSeconds(transitionTime);
        button.GetComponent<Collider2D>().enabled = true;
        anotherButton.GetComponent<Collider2D>().enabled = true;
        isSwapping = false;
    }


    private void OnEndDrag(PointerEventData data, GameObject button)
    {
        if (data.position.y < Screen.height * 0.5f)
        {
            Destroy(button.gameObject);
        }
        else
        {
            UpdateButtonPositions();
        }
    }


}
