using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Connect.Core
{
    public class UIManagerDotGame : MonoBehaviour
    {
        public static UIManagerDotGame instance;
        [Header(" Elements ")]
        [SerializeField] private GameObject _menuPanel;
        [SerializeField] private GameObject _stagePanel;
        [SerializeField] private GameObject _levelPanel;
        [SerializeField] private GameObject settingsPanel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // Kiểm tra lần đầu khởi động game
            if (!PlayerPrefs.HasKey("HasLaunchedBefore"))
            {
                // Lần đầu chơi game, vào Menu Panel
                _menuPanel.SetActive(true);
                _stagePanel.SetActive(false);
                _levelPanel.SetActive(false);
                settingsPanel.SetActive(false);

                // Đánh dấu là đã khởi động lần đầu
                PlayerPrefs.SetInt("HasLaunchedBefore", 1);
                PlayerPrefs.Save();
                return;
            }

            // Kiểm tra nếu quay về từ Game Scene
            bool returningFromGame = PlayerPrefs.GetInt("ReturnToStage", 0) == 1;
            if (returningFromGame)
            {
                _menuPanel.SetActive(false);
                _stagePanel.SetActive(true);
                _levelPanel.SetActive(false);
                settingsPanel.SetActive(false);

                // Xóa trạng thái để tránh ảnh hưởng lần sau
                PlayerPrefs.DeleteKey("ReturnToStage");
                PlayerPrefs.Save();
                return;
            }

            // Kiểm tra trạng thái trước đó (nếu có)
            bool isLevelPanelOpen = PlayerPrefs.GetInt("IsLevelPanelOpen", 0) == 1;

            // Mặc định Menu Panel là giao diện chính
            _menuPanel.SetActive(true);
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(false);
            settingsPanel.SetActive(false);

            if (isLevelPanelOpen)
            {
                int stageNumber = PlayerPrefs.GetInt("SelectedStageNumber", 1);
                string stageName = PlayerPrefs.GetString("SelectedStageName", "Stage 1");
                Color stageColor;
                ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString("SelectedStageColor", "FFFFFF"), out stageColor);

                GameManagerDotGame.Instance.CurrentStage = stageNumber;
                GameManagerDotGame.Instance.StageName = stageName;

                ClickedStage(stageName, stageColor);
            }

            PlayerPrefs.DeleteKey("IsLevelPanelOpen");
        }

        public void ClickedPlay()
        {
            _stagePanel.SetActive(true);

            _menuPanel.SetActive(false);
            _levelPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }

        public void ClickedBackToMenu()
        {
            _menuPanel.SetActive(true);

            _stagePanel.SetActive(false);
            _levelPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }

        public void ClickedBackToStage()
        {
            _stagePanel.SetActive(true);

            _menuPanel.SetActive(false);
            _levelPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }

        public void ActivateLevelPanel()
        {
            if (_levelPanel == null)
            {
                Debug.LogWarning("levelPanel has been destroyed or is null.");
                return;
            }
            _levelPanel.SetActive(true);
            _menuPanel.SetActive(false);
            _stagePanel.SetActive(false);
            settingsPanel.SetActive(false);

            // Retrieve and update stage information
            string stageName = PlayerPrefs.GetString("StageName", "Stage 1");
            string stageColorString = PlayerPrefs.GetString("StageColor", "FFFFFF");
            Color stageColor;
            ColorUtility.TryParseHtmlString("#" + stageColorString, out stageColor);

            _levelTitleText.text = stageName;
            _levelTitleImage.color = stageColor;
        }

        public UnityAction LevelOpened;

        //[HideInInspector]
        public Color CurrentColor;

        [SerializeField]
        private TMP_Text _levelTitleText;
        [SerializeField]
        private Image _levelTitleImage;

        public void ClickedStage(string stageName, Color stageColor)
        {
            _stagePanel.SetActive(false);
            _levelPanel.SetActive(true);
            _menuPanel.SetActive(false);
            settingsPanel.SetActive(false);
            CurrentColor = stageColor;
            _levelTitleText.text = stageName;
            _levelTitleImage.color = CurrentColor;

            // Save stage information to PlayerPrefs
            PlayerPrefs.SetString("StageName", stageName);
            PlayerPrefs.SetString("StageColor", ColorUtility.ToHtmlStringRGBA(stageColor));
            PlayerPrefs.SetInt("SelectedStageNumber", GameManagerDotGame.Instance.CurrentStage);
            PlayerPrefs.SetString("SelectedStageName", stageName);
            PlayerPrefs.SetString("SelectedStageColor", ColorUtility.ToHtmlStringRGBA(stageColor));
            PlayerPrefs.Save();
            LevelOpened?.Invoke();
        }

        // Settings
        public void SettingsButtonCallBack()
        {
            settingsPanel.SetActive(true);
        }

        public void CloseSettingsPanel()
        {
            settingsPanel.SetActive(false);
        }

        public void QuitGameButtonCallBack()
        {
            SceneManager.LoadScene(SceneName.MainMenu.ToString());
        }
    }
}