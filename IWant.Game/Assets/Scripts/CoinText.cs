using UnityEngine;
using TMPro;
public class CoinText : MonoBehaviour
{
    public void UpdateText(string text)  => GetComponent<TextMeshProUGUI>().text = text;
    
}
