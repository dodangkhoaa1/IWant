using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class ShopManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private SkinButton skinButtonPrefab;
    [SerializeField] private Transform skinButtonsParent;
    [SerializeField] private GameObject purchaseButton;
    [SerializeField] private TextMeshProUGUI skinLabelText;
    [SerializeField] private TextMeshProUGUI skinPriceText;

    [SerializeField] private ScrollRect scrollRect;

    [Header(" Data ")]
    [SerializeField] private SkinDataSO[] skinDataSOs;
    private bool[] unlockedStates;
    private const string skinButtonKey = "skinButton_";
    private const string lastSelectedSkinKey = "LastSelectedSkin";

    [Header(" Variables ")]
    private int lastSelectedSkin;

    [Header(" Actions ")]
    public static Action<SkinDataSO> onSkinSelected;



    private void Awake()
    {
        unlockedStates = new bool[skinDataSOs.Length];
    }

    void Start()
    {
        Initialize();
        LoadData();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void PurchaseButtonCallback()
    {

      CoinManager.instance.AddCoins(-skinDataSOs[lastSelectedSkin].GetPrice());

        unlockedStates[lastSelectedSkin] = true;

        SaveData();

        SkinButtonClickedCallback(lastSelectedSkin);
    }

    private void Initialize()
    {

        purchaseButton.SetActive(false);

        for (int i = 0; i < skinDataSOs.Length; i++)
        {
            SkinButton skinButtonInstance = Instantiate(skinButtonPrefab, skinButtonsParent);

            skinButtonInstance.Configure(skinDataSOs[i].GetObjectPrefabs()[0].GetSprite());

            int j = i;
            skinButtonInstance.GetButton().onClick.AddListener(() => SkinButtonClickedCallback(j));
        }


    }

    private void MoveSelectedItemToCenter(int selectedIndex)
    {
        StartCoroutine(MoveToCenterCoroutine(selectedIndex));
    }

    private IEnumerator MoveToCenterCoroutine(int selectedIndex)
    {
        yield return new WaitForEndOfFrame(); // Chờ 1 frame để UI cập nhật

        RectTransform selectedItem = (RectTransform)skinButtonsParent.GetChild(selectedIndex);
        RectTransform contentRect = scrollRect.content;
        RectTransform viewportRect = scrollRect.viewport;

        float viewportWidth = viewportRect.rect.width;
        float contentWidth = contentRect.rect.width;

        // 🟢 Lấy vị trí X của item trong Content
        float itemPosX = selectedItem.anchoredPosition.x;

        // 🟢 Tính toán vị trí trung tâm cần cuộn đến
        float targetX = itemPosX - viewportWidth / 2 + selectedItem.rect.width / 2;

        // 🟢 Chuyển đổi thành giá trị `horizontalNormalizedPosition`
        float normalizedPosition = Mathf.Clamp01(targetX / (contentWidth - viewportWidth));

        // 🟢 Gán giá trị cuộn cho ScrollRect
        scrollRect.horizontalNormalizedPosition = normalizedPosition;

    }



    private void SkinButtonClickedCallback(int skinButtonIndex, bool shouldSaveLastSkin = true)
    {
        lastSelectedSkin = skinButtonIndex;

        for (int i = 0; i < skinButtonsParent.childCount; i++)
        {
            SkinButton currentSkinbutton = skinButtonsParent.GetChild(i).GetComponent<SkinButton>();

            if (i == skinButtonIndex)
            {
                currentSkinbutton.Select();
            }
            else
            {
                currentSkinbutton.Unselect();
            }
        }

        if (IsSkinUnlocked(skinButtonIndex))
        {
            onSkinSelected?.Invoke(skinDataSOs[skinButtonIndex]);

            if (shouldSaveLastSkin)
                SaveLastSelectedSkin();
        }

        ManagePurchaseButtonVisibility(skinButtonIndex);
        UpdateSkinLabel(skinButtonIndex);

        // 🟢 Di chuyển item vào giữa màn hình
        MoveSelectedItemToCenter(skinButtonIndex);
    }

    private void UpdateSkinLabel(int skinButtonIndex)
    {
        skinLabelText.text = skinDataSOs[skinButtonIndex].GetName();
    }
    private void ManagePurchaseButtonVisibility(int skinButtonIndex)
    { 
        bool canPurchase = CoinManager.instance.CanPurchase(skinDataSOs[skinButtonIndex].GetPrice());
        
        purchaseButton.GetComponent<Button>().interactable = canPurchase;
        purchaseButton.SetActive(!IsSkinUnlocked(skinButtonIndex));

        //Update the price text
        skinPriceText.text = skinDataSOs[skinButtonIndex].GetPrice().ToString();
    }

    private bool IsSkinUnlocked(int skinButtonIndex)
    {
        return unlockedStates[skinButtonIndex];
    }

    private void LoadData()
    {
        for (int i = 0; i < unlockedStates.Length; i++)
        {
            int unlockedValue = PlayerPrefs.GetInt(skinButtonKey + i);

            if (i == 0)
                unlockedValue = 1;

            if ((unlockedValue == 1))
            {
                unlockedStates[i] = true;
            }
        }

        LoadLastSelectedSkin();
    }

    private void SaveData()
    {
        for (int i = 0; i < unlockedStates.Length; i++)
        {
            int unlockedValue = unlockedStates[i] ? 1 : 0;

            PlayerPrefs.SetInt(skinButtonKey + i, unlockedValue);
        }
    }

    private void LoadLastSelectedSkin()
    {
        int lastSelectedSkinIndex = PlayerPrefs.GetInt(lastSelectedSkinKey);
        SkinButtonClickedCallback(lastSelectedSkinIndex, false);
    }

    private void SaveLastSelectedSkin()
    {
        PlayerPrefs.SetInt(lastSelectedSkinKey, lastSelectedSkin);
    }
}
