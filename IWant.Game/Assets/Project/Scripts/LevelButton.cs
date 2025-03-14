using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Connect.Core
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;
        [SerializeField] TMP_Text _levelText;
        [SerializeField] private Color _inactiveColor;

        private bool isLevelUnlocked;
        private int currentLevel;

        private void Awake()
        {
            _button.onClick.AddListener(Clicked);
        }

        private void OnEnable()
        {
            UIManagerDotGame.instance.LevelOpened += LevelOpened;
        }

        private void OnDisable()
        {
            UIManagerDotGame.instance.LevelOpened -= LevelOpened;
        }
        private IEnumerator DelayedAction(Action action)
        {
            yield return new WaitForSeconds(.5f);
            action.Invoke();
        }
        private void LevelOpened()
        {
            string gameObjectName = gameObject.name;
            string[] parts = gameObjectName.Split('_');
            _levelText.text = parts[parts.Length - 1];
            currentLevel = int.Parse(_levelText.text);
            isLevelUnlocked = GameManagerDotGame.Instance.IsLevelUnlocked(currentLevel);

            _image.color = isLevelUnlocked ? UIManagerDotGame.instance.CurrentColor : _inactiveColor;
        }

        private void Clicked()
        {
            if (!isLevelUnlocked)
                return;

            StartCoroutine(DelayedAction(() =>
            {
                GameManagerDotGame.Instance.CurrentLevel = currentLevel;
                GameManagerDotGame.Instance.GoToGameplay();
                PlayerPrefs.SetInt("CurrentLevel", currentLevel);
            }));
        }
    }
}
