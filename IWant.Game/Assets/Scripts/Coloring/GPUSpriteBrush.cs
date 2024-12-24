using System.Collections.Generic;
using UnityEngine;

public class GPUSpriteBrush : MonoBehaviour
{
    [Header(" Elements ")]
    private SpriteRenderer currentSpriteRenderer;

    [Header(" Settings ")]
    [SerializeField] private Color color;
    [Range(0, 2)]
    [SerializeField] private float brushSize;
    [SerializeField] private Material brushMaterial;
    private Dictionary<int, Texture2D> originalTextures = new Dictionary<int, Texture2D>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If user click left mouse
        if (Input.GetMouseButtonDown(0))
            RaycastSprites(); // Identify the sprite was clicked
        else if (Input.GetMouseButton(0))
            RaycastCurrentSprite();
    }

    private void RaycastSprites()
    {
        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = Vector2.zero;

        // Get array GO in area was clicked
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction);

        // Ensure there is something was clicked
        if (hits.Length <= 0) return;

        int highestOrderInLayer = int.MinValue;

        int highestOrderIndex = -1;

        for (int i = 0; i < hits.Length; i++)
        {
            SpriteRenderer spriteRenderer = hits[i].collider.GetComponent<SpriteRenderer>();

            // Skip the GO didnt have SpriteRenderer 
            if (spriteRenderer == null) continue;

            // At this point, we have SpriteRenderer
            int orderInLayer = spriteRenderer.sortingOrder;

            if (orderInLayer > highestOrderInLayer)
            {
                highestOrderInLayer = orderInLayer;
                highestOrderIndex = i;
            }
        }

        //At end of loop, we have the highest order in layer
        //Get collider of highest order layer
        Collider2D highestCollider = hits[highestOrderIndex].collider;

        // Store the current sprite renderer
        currentSpriteRenderer = highestCollider.GetComponent<SpriteRenderer>();

        // Check if we have this current sprite original texture or not
        int key = currentSpriteRenderer.transform.GetSiblingIndex();

        if (!originalTextures.ContainsKey(key))
        {
            originalTextures.Add(key, currentSpriteRenderer.sprite.texture);
        }

        //Color it
        ColorSpriteAtPosition(highestCollider, hits[highestOrderIndex].point);
    }
    private void RaycastCurrentSprite()
    {
        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = Vector2.zero;

        // Get array GO in area was clicked
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, direction);

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
    }

    private void ColorSpriteAtPosition(Collider2D collider, Vector2 hitPoint)
    {
        SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();

        //Ensure the GO has SpriteRenderer component
        if (spriteRenderer == null) return;

        //Convert world point to texture point
        Vector2 texturePoint = WorldToTexturePoint(spriteRenderer, hitPoint);

        Sprite sprite = spriteRenderer.sprite;

        int key = currentSpriteRenderer.transform.GetSiblingIndex();

        Texture2D originalTexture = originalTextures[key];

        Texture2D tex = new Texture2D(sprite.texture.width, sprite.texture.height);

        Graphics.CopyTexture(sprite.texture, tex);

        brushMaterial.SetTexture("_MainTex", tex);
        brushMaterial.SetTexture("_Original", originalTexture);
        brushMaterial.SetColor("_Color", Random.ColorHSV());
        brushMaterial.SetFloat("_BrushSize", brushSize);
        brushMaterial.SetVector("_UVPosition", texturePoint / sprite.texture.width);

        RenderTexture rt = new RenderTexture(tex.width, tex.height, 0, RenderTextureFormat.ARGB32, 10);
        rt.useMipMap = true;

        Graphics.Blit(originalTexture, rt, brushMaterial);

        //At this point, we have a colored render texture
        Graphics.CopyTexture(rt, tex);

        //tex.Apply();

        Sprite newSprite = Sprite.Create(tex, sprite.rect, Vector2.one / 2, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;
    }

    private Vector2 WorldToTexturePoint(SpriteRenderer sr, Vector2 worldPos)
    {
        Vector2 texturePoint = sr.transform.InverseTransformPoint(worldPos);

        // Position between -.5 and .5
        texturePoint.x /= sr.bounds.size.x;
        texturePoint.y /= sr.bounds.size.y;

        // Position between 0 and -1
        texturePoint += Vector2.one / 2;

        // Offset in texture space
        texturePoint.x *= sr.sprite.rect.width;
        texturePoint.y *= sr.sprite.rect.height;

        // Position in Texture Space
        texturePoint.x += sr.sprite.rect.x;
        texturePoint.y += sr.sprite.rect.y;


        return texturePoint;
    }

    private void ColorSprite(Collider2D collider)
    {
        SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();

        //Ensure the GO has SpriteRenderer component
        if (spriteRenderer == null) return;

        //Texture2D tex = spriteRenderer.sprite.texture;
        Sprite sprite = spriteRenderer.sprite;

        Texture2D tex = new Texture2D(sprite.texture.width, sprite.texture.height);

        for (int x = 0; x < tex.width; x++)
        {
            for (int y = 0; y < tex.height; y++)
            {
                Color pixelColor = color;
                pixelColor.a = sprite.texture.GetPixel(x, y).a;

                pixelColor *= sprite.texture.GetPixel(x, y);

                tex.SetPixel(x, y, pixelColor);
            }
        }
        tex.Apply();

        Sprite newSprite = Sprite.Create(tex, sprite.rect, Vector2.one / 2, sprite.pixelsPerUnit);
        spriteRenderer.sprite = newSprite;
    }
}
