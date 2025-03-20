using Connect.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Connect.Core
{
    public class GameplayManagerDotGame : MonoBehaviour
    {
        #region START_METHODS

        #region START_VARIABLES
        public static GameplayManagerDotGame Instance;

        [HideInInspector] public bool hasGameFinished;

        [Header(" Elements ")]
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private GameObject _winText;
        [SerializeField] private SpriteRenderer _clickHighlight;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private GameObject settingsPanel;
        [Header(" Action ")]
        public static Action onNodeClicked;
        public static Action onNodeSolvedError;

        private const string HighScoreDotGame = "HighScoreDotGame";
        private void Awake()
        {
            Instance = this;

            hasGameFinished = false;

            if (_winText != null)
            {
                _winText.SetActive(false);
            }
            else
            {
                Debug.LogWarning("_winText is not assigned in the Inspector.");
            }

            if (_titleText != null)
            {
                _titleText.gameObject.SetActive(true);
                _titleText.text = GameManagerDotGame.Instance.StageName +
                    " - " + GameManagerDotGame.Instance.CurrentLevel.ToString();
            }
            else
            {
                Debug.LogWarning("_titleText is not assigned in the Inspector.");
            }

            CurrentLevelData = GameManagerDotGame.Instance.GetLevel();

            SpawnBoard();
            SpawnNodes();

            if (_mainMenuButton != null)
            {
                _mainMenuButton.onClick.AddListener(GameManagerDotGame.Instance.GoToMainMenuAndActivateLevelPanel);
            }
            else
            {
                Debug.LogWarning("_mainMenuButton is not assigned in the Inspector.");
            }
        }

        #endregion

        #region HIGHSCORE

        public static event System.Action<int> OnHighScoreChanged;
        public int HighScore
        {
            get => PlayerPrefs.GetInt(HighScoreDotGame, 0);
            set
            {
                PlayerPrefs.SetInt(HighScoreDotGame, value);
                OnHighScoreChanged?.Invoke(value);
            }
        }

        public void AddScore(int score)
        {
            HighScore += score;
        }
        public void UpdateHighScoreUI()
        {
            // Cập nhật UI để hiển thị điểm số cao nhất
            ScoreMangerDotGame.instance.UpdateHighScoreUI(HighScore);
        }
        #endregion

        #region BOARD_SPAWN

        [SerializeField] private SpriteRenderer _boardPrefab, _bgCellPrefab;

        private void SpawnBoard()
        {
            if (_boardPrefab == null)
            {
                Debug.LogWarning("_boardPrefab is not assigned in the Inspector.");
                return;
            }

            int currentLevelSize = GameManagerDotGame.Instance.CurrentStage + 4;

            var board = Instantiate(_boardPrefab,
                new Vector3(currentLevelSize / 2f, currentLevelSize / 2f, 0f),
                Quaternion.identity);

            board.size = new Vector2(currentLevelSize + 0.08f, currentLevelSize + 0.08f);

            for (int i = 0; i < currentLevelSize; i++)
            {
                for (int j = 0; j < currentLevelSize; j++)
                {
                    Instantiate(_bgCellPrefab, new Vector3(i + 0.5f, j + 0.5f, 0f), Quaternion.identity);
                }
            }

            Camera.main.orthographicSize = currentLevelSize + 2f;
            Camera.main.transform.position = new Vector3(currentLevelSize / 2f, currentLevelSize / 2f, -10f);

            _clickHighlight.size = new Vector2(currentLevelSize / 4f, currentLevelSize / 4f);
            _clickHighlight.transform.position = Vector3.zero;
            _clickHighlight.gameObject.SetActive(false);
        }

        #endregion

        #region NODE_SPAWN

        private LevelData CurrentLevelData;
        [SerializeField] private Node _nodePrefab;
        private List<Node> _nodes;

        public Dictionary<Vector2Int, Node> _nodeGrid;

        private void SpawnNodes()
        {
            if (_nodePrefab == null)
            {
                Debug.LogError("_nodePrefab is not assigned in the Inspector.");
                return;
            }

            _nodes = new List<Node>();
            _nodeGrid = new Dictionary<Vector2Int, Node>();

            int currentLevelSize = GameManagerDotGame.Instance.CurrentStage + 4;
            Node spawnedNode;
            Vector3 spawnPos;

            for (int i = 0; i < currentLevelSize; i++)
            {
                for (int j = 0; j < currentLevelSize; j++)
                {
                    spawnPos = new Vector3(i + 0.5f, j + 0.5f, 0f);
                    spawnedNode = Instantiate(_nodePrefab, spawnPos, Quaternion.identity);
                    spawnedNode.Init();

                    int colorIdForSpawnedNode = GetColorId(i, j);

                    if (colorIdForSpawnedNode != -1)
                    {
                        spawnedNode.SetColorForPoint(colorIdForSpawnedNode);
                    }

                    _nodes.Add(spawnedNode);
                    _nodeGrid.Add(new Vector2Int(i, j), spawnedNode);
                    spawnedNode.gameObject.name = i.ToString() + j.ToString();
                    spawnedNode.Pos2D = new Vector2Int(i, j);
                }
            }

            List<Vector2Int> offsetPos = new List<Vector2Int>()
        {Vector2Int.up,Vector2Int.down,Vector2Int.left,Vector2Int.right };

            foreach (var item in _nodeGrid)
            {
                foreach (var offset in offsetPos)
                {
                    var checkPos = item.Key + offset;
                    if (_nodeGrid.ContainsKey(checkPos))
                    {
                        item.Value.SetEdge(offset, _nodeGrid[checkPos]);
                    }
                }
            }
        }

        public List<Color> NodeColors;

        public int GetColorId(int i, int j)
        {
            List<Edge> edges = CurrentLevelData.Edges;
            Vector2Int point = new Vector2Int(i, j);

            for (int colorId = 0; colorId < edges.Count; colorId++)
            {
                if (edges[colorId].StartPoint == point ||
                    edges[colorId].EndPoint == point)
                {
                    return colorId;
                }
            }

            return -1;
        }

        public Color GetHighLightColor(int colorID)
        {
            Color result = NodeColors[colorID % NodeColors.Count];
            result.a = 0.4f;
            return result;
        }


        #endregion

        #endregion

        #region UPDATE_METHODS

        private Node startNode;

        private void Update()
        {
            if (hasGameFinished) return;

            if (Input.GetMouseButtonDown(0))
            {
                startNode = null;
                return;
            }

            if (Input.GetMouseButton(0))
            {

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (startNode == null)
                {
                    if (hit && hit.collider.gameObject.TryGetComponent(out Node tNode)
                        && tNode.IsClickable)
                    {
                        startNode = tNode;
                        _clickHighlight.gameObject.SetActive(true);
                        _clickHighlight.gameObject.transform.position = (Vector3)mousePos2D;
                        _clickHighlight.color = GetHighLightColor(tNode.colorId);

                        onNodeClicked?.Invoke();
                    }

                    return;
                }

                _clickHighlight.gameObject.transform.position = (Vector3)mousePos2D;

                if (hit && hit.collider.gameObject.TryGetComponent(out Node tempNode)
                    && startNode != tempNode)
                {
                    if (startNode.colorId != tempNode.colorId && tempNode.IsEndNode)
                    {
                        onNodeSolvedError?.Invoke();
                        return;
                    }

                    startNode.UpdateInput(tempNode);
                    // Check if the level is already completed before calling CheckWin()
                    if (!GameManagerDotGame.Instance.IsLevelCompleted(GameManagerDotGame.Instance.CurrentStage, GameManagerDotGame.Instance.CurrentLevel))
                    {
                        CheckWin();
                    }
                    else
                    {
                        CheckHighlight();
                    }
                    startNode = null;
                }

                return;
            }

            if (Input.GetMouseButtonUp(0))
            {
                startNode = null;
                _clickHighlight.gameObject.SetActive(false);
            }

        }

        #endregion

        #region WIN_CONDITION
        private void CheckHighlight()
        {
            foreach (var item in _nodes)
            {
                item.SolveHighlight();
            }
            _clickHighlight.gameObject.SetActive(false);
        }

        private void CheckWin()
        {
            bool IsWinning = true;

            foreach (var item in _nodes)
            {
                item.SolveHighlight();
            }

            foreach (var item in _nodes)
            {
                IsWinning &= item.IsWin;
                if (!IsWinning)
                {
                    return;
                }
            }

            // Kiểm tra xem level đã hoàn thành trước đó hay chưa
            if (!GameManagerDotGame.Instance.IsLevelCompleted(GameManagerDotGame.Instance.CurrentStage, GameManagerDotGame.Instance.CurrentLevel))
            {
                // Cộng 100 điểm vào điểm số cao nhất khi hoàn thành level lần đầu tiên
                AddScore(100);
                GameManagerDotGame.Instance.SetLevelCompleted(GameManagerDotGame.Instance.CurrentStage, GameManagerDotGame.Instance.CurrentLevel);
            }
           GameManagerDotGame.Instance.SaveLastLevel();
            GameManagerDotGame.Instance.UnlockLevel();

            _winText.gameObject.SetActive(true);
            _clickHighlight.gameObject.SetActive(false);

            hasGameFinished = true;

            // Cập nhật UI để hiển thị điểm số cao nhất
            UpdateHighScoreUI();
        }
        #endregion

        #region BUTTON_FUNCTIONS
        private IEnumerator DelayedAction(Action action)
        {
            yield return new WaitForSeconds(.5f);
            action.Invoke();
        }
        public void ClickedBack()
        {
            StartCoroutine(DelayedAction(GameManagerDotGame.Instance.GoToPreviousLevel));
        }

        public void ClickedRestart()
        {
            StartCoroutine(DelayedAction(GameManagerDotGame.Instance.RestartCurrentLevel));
        }

        public void ClickedNextLevel()
        {
            StartCoroutine(DelayedAction(GameManagerDotGame.Instance.GoToNextLevel));
        }


        public void ClickedLevelPanel()
        {
            GameManagerDotGame.Instance.GoToMainMenuAndActivateLevelPanel();
        }

        public void ClickedStagePanel()
        {
            GameManagerDotGame.Instance.GoToMainMenuAndActivateStagePanel();
        }

        public void ClickedMainMenu()
        {
            GameManagerDotGame.Instance.GoToMainMenu();
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
        #endregion
    }
}
