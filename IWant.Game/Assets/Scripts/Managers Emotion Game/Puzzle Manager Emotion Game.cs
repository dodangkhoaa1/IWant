using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManagerEmotionGame : MonoBehaviour
{
    public static PuzzleManagerEmotionGame instance;

    [SerializeField] private List<PuzzleSlotEmotionGame> _slotPrefabs;
    [SerializeField] private PuzzlePieceEmotionGame _piecePrefab;
    [SerializeField] private Transform _slotParent;
    [SerializeField] private Transform _pieceParent;
    [SerializeField] private TimeManagerEmotionGame timeManager;  // Nếu có

    private int placedCount = 0;    // Số mảnh đã được đặt đúng
    private int totalSlotCount = 0; // Tổng số slot trong level hiện tại

    private void Awake()
    {
        instance = this;
        if (_slotParent == null)
            _slotParent = transform.Find("Slot Parent");
        if (_pieceParent == null)
            _pieceParent = transform.Find("Piece Parent");
    }

    private void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        totalSlotCount = _slotParent.childCount;
        placedCount = 0; // Reset số mảnh đã đặt

        Debug.Log("SlotParent children count: " + _slotParent.childCount);
        Debug.Log("PieceParent children count: " + _pieceParent.childCount);

        // Lấy danh sách các slot prefab ngẫu nhiên, số lượng = totalSlotCount
        var randomSet = _slotPrefabs.OrderBy(s => Random.value).Take(totalSlotCount).ToList();

        for (int i = 0; i < randomSet.Count; i++)
        {
            // Instantiate slot tại vị trí của con thứ i trong _slotParent
            var spawnedSlot = Instantiate(randomSet[i], _slotParent.GetChild(i).position, Quaternion.identity, _slotParent);
            Destroy(_slotParent.GetChild(i).gameObject);

            // Instantiate piece tại vị trí của con thứ i trong _pieceParent
            var spawnedPiece = Instantiate(_piecePrefab, _pieceParent.GetChild(i).position, Quaternion.identity, _pieceParent);
            spawnedPiece.Init(spawnedSlot);
            Destroy(_pieceParent.GetChild(i).gameObject);
        }
    }

    // Được gọi khi mỗi mảnh được đặt đúng
    public void OnPiecePlaced()
    {
        placedCount++;
        Debug.Log("Placed count: " + placedCount + "/" + totalSlotCount);
        if (placedCount >= totalSlotCount)
        {
            OnPuzzleCompleted();
        }
    }

    public void OnPuzzleCompleted()
    {
        TimeManagerEmotionGame.instance.StopTimer();
        Debug.Log("Puzzle Completed!");
        ScoreManagerEmotionGame.instance.LevelCompleted();
        StartCoroutine(WaitAndTransitionLevel(2f));
    }

    private IEnumerator WaitAndTransitionLevel(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Sử dụng LevelManager để chuyển level
        LevelManagerEmotionGame.instance.TransitionLevel();
        // Hủy PuzzleManager của level cũ (vì level mới sẽ có PuzzleManager riêng)
        Destroy(gameObject);
    }
}
