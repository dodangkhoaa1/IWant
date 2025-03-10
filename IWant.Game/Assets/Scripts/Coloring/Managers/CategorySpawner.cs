using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum Category
{
    Animals,
    Foods,
    Fruits,
    Flowers
}

public class CategorySpawner : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Transform pictureContainer;

    [SerializeField] private Category[] categories = { Category.Animals, Category.Foods, Category.Fruits, Category.Flowers };
    private string[] categoriesVN = { "Động Vật", "Thức Ăn", "Trái Cây", "Hoa" };
    [SerializeField] private Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        SpawnMenuPictures();
    }
    private void SpawnMenuPictures()
    {
        for (int i = 0; i < categories.Length; i++)
        {
            GameObject buttonGO = Instantiate(buttonPrefab, pictureContainer);
            buttonGO.transform.GetChild(0).GetComponent<Image>().sprite = sprites[i];
            buttonGO.GetComponentInChildren<TextMeshProUGUI>().text = PrefsKey.LANGUAGE == PrefsKey.ENGLISH_CODE
                        ? categories[i].ToString() : categoriesVN[i];

            int index = i;
            buttonGO.GetComponent<Button>().onClick.AddListener(() =>
            {
                Debug.Log(categories[index]);
                ChooseCategory(categories[index]);

            });

        }
    }

    private void ChooseCategory(Category categoryName)
    {

        MenuColoringManagement.instance.INDEX_OF_CHOSE_CATEGORY = categoryName;
        SceneManager.LoadScene(SceneName.PictureSelection.ToString());
    }
}
