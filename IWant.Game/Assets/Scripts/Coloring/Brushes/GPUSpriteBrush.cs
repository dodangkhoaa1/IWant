using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPUSpriteBrush : MonoBehaviour
{
    public static GPUSpriteBrush instance;

    [Header(" Elements ")]
    private Transform spriteRenderersParent;
    private SpriteRenderer currentSpriteRenderer;
    [SerializeField] private BrushSizeManager brushSizeManager;

    [Header(" Settings ")]
    [SerializeField] private Color brushColor = Color.green;
    [Range(0, 2)]
    [SerializeField] private float brushSize;
    [SerializeField] private Material brushMaterial;
    private Dictionary<int, Texture2D> originalTextures = new Dictionary<int, Texture2D>();
    private Dictionary<int, Texture2D> editedTextures = new Dictionary<int, Texture2D>();
    private Dictionary<int, RenderTexture> renderTextures = new Dictionary<int, RenderTexture>();

    [Header(" Undo ")]
    [SerializeField] private List<UndoObject> undoObjects = new List<UndoObject>();
    [SerializeField] private Button undoButton;

    [Header(" Redo ")]
    [SerializeField] private List<UndoObject> redoObjects = new List<UndoObject>();
    [SerializeField] private Button redoButton;

    [Header(" Improvements ")]
    private Vector2 previousMousePosition;

    private void Awake()
    {
        // Ensure there is only one instance of GPUSpriteBrush
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Allow to set the target frame rate for the application
    void Start()
    {
        Application.targetFrameRate = 60;
        spriteRenderersParent = GameObject.FindWithTag("PictureToColor").transform;
    }

    // Allow to check for mouse input to start or continue painting
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastSprites();
        }
        else if (Input.GetMouseButton(0))
        {
            RaycastCurrentSprite();
        }
    }

    // Allow to raycast sprites and start painting
    private void RaycastSprites()
    {
        previousMousePosition = Input.mousePosition;
        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector2.zero);

        if (hits.Length <= 0) return;

        int highestOrderInLayer = int.MinValue;
        int highestOrderIndex = -1;

        // Find the sprite with the highest sorting order
        for (int i = 0; i < hits.Length; i++)
        {
            SpriteRenderer spriteRenderer = hits[i].collider.GetComponent<SpriteRenderer>();
            if (spriteRenderer == null) continue;

            int orderInLayer = spriteRenderer.sortingOrder;
            if (orderInLayer > highestOrderInLayer)
            {
                highestOrderInLayer = orderInLayer;
                highestOrderIndex = i;
            }
        }

        Collider2D highestCollider = hits[highestOrderIndex].collider;
        currentSpriteRenderer = highestCollider.GetComponent<SpriteRenderer>();

        int key = currentSpriteRenderer.transform.GetSiblingIndex();
        int width = currentSpriteRenderer.sprite.texture.width;
        int height = currentSpriteRenderer.sprite.texture.height;

        Texture2D undoTexture = new Texture2D(width, height);

        // Store the original and edited textures for undo/redo functionality
        if (!originalTextures.ContainsKey(key))
        {
            originalTextures.Add(key, currentSpriteRenderer.sprite.texture);
            editedTextures.Add(key, new Texture2D(width, height));

            RenderTexture renderTexture = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32, 10)
            {
                useMipMap = true
            };

            renderTextures.Add(key, renderTexture);
            Graphics.CopyTexture(originalTextures[key], undoTexture);
        }
        else
        {
            Graphics.CopyTexture(editedTextures[key], undoTexture);
        }

        undoObjects.Add(new UndoObject(key, undoTexture));
        redoObjects.Clear();
        UpdateButtonUI();

        ColorSpriteAtPosition(highestCollider, hits[highestOrderIndex].point);
    }

    // Allow to continue painting on the current sprite
    private void RaycastCurrentSprite()
    {
        if ((Vector2)Input.mousePosition == previousMousePosition) return;

        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector2.zero);

        if (hits.Length <= 0) return;

        for (int i = 0; i < hits.Length; i++)
        {
            if (!hits[i].collider.TryGetComponent(out SpriteRenderer spriteRenderer)) continue;

            if (spriteRenderer == currentSpriteRenderer)
            {
                ColorSpriteAtPosition(hits[i].collider, hits[i].point);
                break;
            }
        }

        previousMousePosition = Input.mousePosition;
    }

    // Allow to color the sprite at the specified position
    private void ColorSpriteAtPosition(Collider2D collider, Vector2 hitPoint)
    {
        SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();
        if (spriteRenderer == null) return;

        Vector2 texturePoint = WorldToTexturePoint(spriteRenderer, hitPoint);
        Sprite sprite = spriteRenderer.sprite;

        int key = currentSpriteRenderer.transform.GetSiblingIndex();
        Texture2D originalTexture = originalTextures[key];
        Texture2D tex = editedTextures[key];

        if (sprite.texture != tex)
        {
            Graphics.CopyTexture(sprite.texture, tex);
        }

        // Set brush material properties
        brushMaterial.SetTexture("_MainTex", tex);
        brushMaterial.SetTexture("_Original", originalTexture);
        brushMaterial.SetColor("_Color", brushColor);
        brushMaterial.SetFloat("_BrushSize", brushSize);
        brushMaterial.SetVector("_UVPosition", texturePoint / sprite.texture.width);

        RenderTexture renderTexture = renderTextures[key];
        Graphics.Blit(tex, renderTexture, brushMaterial);
        Graphics.CopyTexture(renderTexture, tex);

        // Create a new sprite with the edited texture
        Sprite newSprite = Sprite.Create(tex, sprite.rect, Vector2.one / 2, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;
    }

    // Allow to convert world position to texture coordinates
    private Vector2 WorldToTexturePoint(SpriteRenderer spriteRenderer, Vector2 worldPos)
    {
        Vector2 texturePoint = spriteRenderer.transform.InverseTransformPoint(worldPos);
        texturePoint.x /= spriteRenderer.bounds.size.x;
        texturePoint.y /= spriteRenderer.bounds.size.y;
        texturePoint += Vector2.one / 2;
        texturePoint.x *= spriteRenderer.sprite.rect.width;
        texturePoint.y *= spriteRenderer.sprite.rect.height;
        texturePoint.x += spriteRenderer.sprite.rect.x;
        texturePoint.y += spriteRenderer.sprite.rect.y;

        return texturePoint;
    }

    // Allow to set the brush size
    public void SetBrushSize(float brushSize)
    {
        this.brushSize = brushSize;
    }

    // Allow to set the brush color
    public void SetColor(Color color)
    {
        this.brushColor = color;
        brushSizeManager.selectedColor = color;
        brushSizeManager.UpdateSelectedBrushColor(color);
    }

    // Allow to set brush texture and hardness
    public void SetBrush(BrushData brushData)
    {
        brushMaterial.SetTexture("_BrushTexture", brushData.Texture);
        brushMaterial.SetFloat("_Hardness", brushData.Hardness);
    }

    // Allow to undo the last action
    public void Undo()
    {
        if (undoObjects.Count <= 0) return;

        UndoObject undoObj = undoObjects[undoObjects.Count - 1];
        int key = undoObj.spriteIndex;
        Texture2D redoTexture = new Texture2D(editedTextures[key].width, editedTextures[key].height);
        Graphics.CopyTexture(editedTextures[key], redoTexture);
        redoObjects.Add(new UndoObject(key, redoTexture));

        Graphics.CopyTexture(undoObj.texture, editedTextures[undoObj.spriteIndex]);

        SpriteRenderer spriteRenderer = spriteRenderersParent.GetChild(undoObj.spriteIndex).GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;
        Sprite newSprite = Sprite.Create(editedTextures[undoObj.spriteIndex], sprite.rect, Vector2.one / 2, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;

        LeanTween.delayedCall(gameObject, Time.deltaTime * 2, () => RemoveLastUndo(undoObj));
    }

    // Allow to remove the last undo object and update the UI
    private void RemoveLastUndo(UndoObject undoObj)
    {
        undoObjects.Remove(undoObj);
        UpdateButtonUI();
    }

    // Allow to redo the last undone action
    public void Redo()
    {
        if (redoObjects.Count <= 0) return;

        UndoObject redoObj = redoObjects[redoObjects.Count - 1];
        int key = redoObj.spriteIndex;
        Texture2D undoTexture = new Texture2D(editedTextures[key].width, editedTextures[key].height);
        Graphics.CopyTexture(editedTextures[key], undoTexture);
        undoObjects.Add(new UndoObject(key, undoTexture));

        Graphics.CopyTexture(redoObj.texture, editedTextures[redoObj.spriteIndex]);

        SpriteRenderer spriteRenderer = spriteRenderersParent.GetChild(redoObj.spriteIndex).GetComponent<SpriteRenderer>();
        Sprite sprite = spriteRenderer.sprite;
        Sprite newSprite = Sprite.Create(editedTextures[redoObj.spriteIndex], sprite.rect, Vector2.one / 2, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;

        LeanTween.delayedCall(gameObject, Time.deltaTime * 2, () => RemoveLastRedo(redoObj));
    }

    // Allow to remove the last redo object and update the UI
    private void RemoveLastRedo(UndoObject redoObj)
    {
        redoObjects.Remove(redoObj);
        UpdateButtonUI();
    }

    // Allow to update the interactable state of undo and redo buttons
    private void UpdateButtonUI()
    {
        undoButton.interactable = undoObjects.Count > 0;
        redoButton.interactable = redoObjects.Count > 0;
    }
}
[System.Serializable]
public class UndoObject
{
    public int spriteIndex;
    public Texture2D texture;

    public UndoObject(int spriteIndex, Texture2D texture)
    {
        this.spriteIndex = spriteIndex;
        this.texture = texture;
    }
}
