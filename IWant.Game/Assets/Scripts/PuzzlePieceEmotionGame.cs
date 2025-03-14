using TMPro;
using UnityEngine;

public class PuzzlePieceEmotionGame : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private AudioClip _dropClip, _pickUpClip;

    private bool _dragging, _placed;
    private Vector2 _offset, _originalPosition;
    private PuzzleSlotEmotionGame _slot;

    public void Init(PuzzleSlotEmotionGame slot)
    {
        if (slot == null)
        {
            Debug.LogError("PuzzlePiece.Init received a null slot!");
            return;
        }

        _renderer.sprite = slot.Renderer.sprite;
        _slot = slot;
    }

    private void Awake()
    {
        _originalPosition = transform.position;
        AudioManagerEmotionGame.instance.RegisterSFXSource(_source);
    }

    private void Update()
    {
        if (_placed) return;

        if (!Application.isEditor) // Dùng Touch Input cho Android
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        if (IsTouchingMe(touchPos))
                        {
                            _dragging = true;
                            _offset = touchPos - (Vector2)transform.position;

                            if (AudioManagerEmotionGame.instance != null)
                            {
                                AudioManagerEmotionGame.instance.PlaySFX(_source, _pickUpClip);
                            }
                        }
                        break;

                    case TouchPhase.Moved:
                        if (_dragging)
                        {
                            transform.position = touchPos - _offset;
                        }
                        break;

                    case TouchPhase.Ended:
                        if (_dragging)
                        {
                            _dragging = false;
                            HandlePiecePlacement();
                        }
                        break;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        if (Application.isEditor) // Giữ lại OnMouseDown cho PC
        {
            _dragging = true;
            _offset = GetMousePos() - (Vector2)transform.position;

            if (AudioManagerEmotionGame.instance != null)
            {
                AudioManagerEmotionGame.instance.PlaySFX(_source, _pickUpClip);
            }
        }
    }

    private void OnMouseUp()
    {
        if (Application.isEditor) // Giữ lại OnMouseUp cho PC
        {
            _dragging = false;
            HandlePiecePlacement();
        }
    }

    private void HandlePiecePlacement()
    {
        if (_slot == null)
        {
            Debug.LogError("PuzzlePiece.HandlePiecePlacement: _slot is null!");
            return;
        }

        if (Vector2.Distance(transform.position, _slot.transform.position) < 1f)
        {
            if (!_placed)
            {
                transform.position = _slot.transform.position;
                _placed = true;
                _slot.Placed();
                PuzzleManagerEmotionGame.instance.OnPiecePlaced();
                _renderer.color = Color.white;
            }
        }
        else
        {
            transform.position = _originalPosition;
            if (AudioManagerEmotionGame.instance != null)
            {
                AudioManagerEmotionGame.instance.PlaySFX(_source, _dropClip);
            }
        }
    }

    private Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private bool IsTouchingMe(Vector2 touchPos)
    {
        Collider2D col = GetComponent<Collider2D>();
        return col != null && col.OverlapPoint(touchPos);
    }
}
