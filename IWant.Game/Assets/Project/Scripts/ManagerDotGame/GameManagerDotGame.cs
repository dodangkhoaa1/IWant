using Connect.Common;
using EasyUI.Helpers;
using EasyUI.Toast;
using System.Collections.Generic;
using UnityEngine;

namespace Connect.Core
{
    public class GameManagerDotGame : MonoBehaviour
    {
        #region START_METHODS

        public static GameManagerDotGame Instance;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                Init();
                DontDestroyOnLoad(gameObject);
                return;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Init()
        {
            CurrentStage = PlayerPrefs.GetInt("CurrentStage", 1);
            CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

            Levels = new Dictionary<string, LevelData>();

            foreach (var item in _allLevels.Levels)
            {
                Levels[item.LevelName] = item;
            }
        }

        #endregion

        #region GAME_VARIABLES

        [HideInInspector]
        public int CurrentStage;

        [HideInInspector]
        public int CurrentLevel;

        [HideInInspector]
        public string StageName;

        public bool IsLevelUnlocked(int level)
        {
            string levelName = "Level" + CurrentStage.ToString() + level.ToString();

            if (level == 1)
            {
                PlayerPrefs.SetInt(levelName, 1);
                return true;
            }

            if (PlayerPrefs.HasKey(levelName))
            {
                return PlayerPrefs.GetInt(levelName) == 1;
            }

            PlayerPrefs.SetInt(levelName, 0);
            return false;
        }

        //public void UnlockLevel()
        //{
        //    Debug.Log($"Unlocking next level. CurrentStage: {CurrentStage}, CurrentLevel: {CurrentLevel}");

        //    CurrentLevel++;

        //    if (CurrentLevel > 20) // Giả sử mỗi stage có 20 level
        //    {
        //        CurrentLevel = 1;
        //        CurrentStage++;

        //        if (CurrentStage > 5) // Giả sử có tối đa 5 stages
        //        {
        //            CurrentStage = 1;
        //            GoToMainMenu();
        //            return;
        //        }
        //    }

        //    string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();
        //    PlayerPrefs.SetInt(levelName, 1); // Lưu trạng thái unlock level
        //    PlayerPrefs.SetInt("CurrentStage", CurrentStage);
        //    PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        //    PlayerPrefs.Save();

        //    Debug.Log($"Next level unlocked. New CurrentStage: {CurrentStage}, New CurrentLevel: {CurrentLevel}");
        //}
        public void UnlockLevel()
        {
            Debug.Log($"Unlocking next level for Stage: {CurrentStage}, Level: {CurrentLevel}");

            string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();
            PlayerPrefs.SetInt(levelName, 1); // Đánh dấu level này đã được mở khóa
            PlayerPrefs.Save();

            Debug.Log($"Unlocked Level: {levelName}");
        }

        public bool IsLevelCompleted(int stage, int level)
        {
            string key = $"Level_{stage}_{level}_Completed";
            return PlayerPrefs.GetInt(key, 0) == 1;
        }

        public void SetLevelCompleted(int stage, int level)
        {
            string key = $"Level_{stage}_{level}_Completed";
            PlayerPrefs.SetInt(key, 1);
        }

        #endregion

        #region LEVEL_DATA

        [SerializeField]
        private LevelData DefaultLevel;

        [SerializeField]
        private LevelList _allLevels;

        private Dictionary<string, LevelData> Levels;

        public LevelData GetLevel()
        {
            string levelName = "Level" + CurrentStage.ToString() + CurrentLevel.ToString();

            if (Levels.ContainsKey(levelName))
            {
                return Levels[levelName];
            }

            return DefaultLevel;
        }

        #endregion

        #region SCENE_LOAD

        private const string MainMenu = "MainMenus";
        private const string Gameplay = "Gameplay";

        public void GoToMainMenu()
        {
            PlayerPrefs.SetInt("IsLevelPanelOpen", 1);
            UnityEngine.SceneManagement.SceneManager.LoadScene(MainMenu);
        }

        public void GoToGameplay()
        {
            Debug.Log("Loading Gameplay scene...");
            UnityEngine.SceneManagement.SceneManager.LoadScene(Gameplay);
        }
        public void RestartCurrentLevel()
        {
            Debug.Log($"Restarting current level. CurrentStage: {CurrentStage}, CurrentLevel: {CurrentLevel}, hasGameFinished: {GameplayManagerDotGame.Instance.hasGameFinished}");
            // Đảm bảo lấy lại level chính xác từ PlayerPrefs
            CurrentStage = PlayerPrefs.GetInt("CurrentStage", CurrentStage);
            CurrentLevel = PlayerPrefs.GetInt("CurrentLevel", CurrentLevel);

            PlayerPrefs.Save();

            GoToGameplay();
        }

        public void GoToPreviousLevel()
        {
            if (CurrentLevel > 1)
            {
                CurrentLevel--;
            }
            else
            {
                Toast.Show("You are already at the first level of this stage.", 2f, ToastColor.Red, ToastPosition.BottomCenter);
                return;
            }

            // Lấy lại StageName từ PlayerPrefs để tránh bị mất khi load lại LevelPanel
            StageName = PlayerPrefs.GetString("StageName", "Default Stage");

            // Lưu lại stage và level hiện tại
            PlayerPrefs.SetInt("CurrentStage", CurrentStage);
            PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
            PlayerPrefs.SetString("StageName", StageName); // Đảm bảo lưu StageName
            PlayerPrefs.Save();

            Debug.Log($"Going to previous level. CurrentStage: {CurrentStage}, CurrentLevel: {CurrentLevel}, StageName: {StageName}");

            // Update UI để giữ lại Stage Name
            UIManagerDotGame.instance.UpdateTitle(StageName, CurrentLevel);

            GoToGameplay();
        }


        public void GoToNextLevel()
        {
            Debug.Log($"Attempting to go to next level. CurrentStage: {CurrentStage}, CurrentLevel: {CurrentLevel}");

            if (IsLevelCompleted(CurrentStage, CurrentLevel))
            {
                if (CurrentLevel < 20)
                {
                    CurrentLevel++;
                }
                else
                {
                    GoToMainMenuAndActivateStagePanel();
                    return;
                }

                // Lấy lại StageName từ PlayerPrefs để tránh bị mất
                StageName = PlayerPrefs.GetString("StageName", "Default Stage");

                // Lưu lại StageName vào PlayerPrefs
                PlayerPrefs.SetInt("CurrentStage", CurrentStage);
                PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
                PlayerPrefs.SetString("StageName", StageName);
                PlayerPrefs.Save();

                // Mở khóa level sau khi cập nhật stage & level
                UnlockLevel();

                Debug.Log($"Moving to next level. New CurrentStage: {CurrentStage}, New CurrentLevel: {CurrentLevel}, StageName: {StageName}");

                // Update UI
                UIManagerDotGame.instance.UpdateTitle(StageName, CurrentLevel);

                GoToGameplay();
            }
            else
            {
                Toast.Show("Complete the current level to unlock the next level.", 2f, ToastColor.Red, ToastPosition.BottomCenter);
            }
        }

        public void GoToMainMenuAndActivateLevelPanel()
        {
            GoToMainMenu();
            UIManagerDotGame.instance.ActivateLevelPanel();
        }

        public void GoToMainMenuAndActivateStagePanel()
        {
            PlayerPrefs.DeleteKey("IsLevelPanelOpen");
            PlayerPrefs.SetInt("ReturnToStage", 1);
            PlayerPrefs.Save();
            GoToMainMenu();
        }
        public void SaveLastLevel()
        {
            PlayerPrefs.SetInt($"LastLevel_Stage{CurrentStage}", CurrentLevel);
            PlayerPrefs.Save();
        }

        #endregion
    }
}
