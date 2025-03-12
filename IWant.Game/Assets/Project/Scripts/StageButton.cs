using UnityEngine;
using UnityEngine.UI;

namespace Connect.Core
{
    public class StageButton : MonoBehaviour
    {
        [SerializeField] private string _stageName;
        [SerializeField] private Color _stageColor;
        [SerializeField] private int _stageNumber;
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(ClickedButton);
        }

        private void ClickedButton()
        {
            GameManagerDotGame.Instance.CurrentStage = _stageNumber;
            GameManagerDotGame.Instance.StageName = _stageName;

            // Store the selected stage information in PlayerPrefs
            PlayerPrefs.SetInt("SelectedStageNumber", _stageNumber);
            PlayerPrefs.SetString("SelectedStageName", _stageName);
            PlayerPrefs.SetString("SelectedStageColor", ColorUtility.ToHtmlStringRGBA(_stageColor));


            UIManagerDotGame.instance.ClickedStage(_stageName, _stageColor);
        }

    }
}
