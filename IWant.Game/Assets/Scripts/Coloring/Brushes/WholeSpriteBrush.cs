using System;
using UnityEngine;

public class WholeSpriteBrush : MonoBehaviour
{

    [Header(" Settings ")]
    [SerializeField] private Color color;
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
    }

    // Allow to raycast a single sprite
    private void RaycastSprite()
    {
        Vector2 origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = Vector2.zero;

        RaycastHit2D hit = Physics2D.Raycast(origin, direction);

        if (hit.collider == null) //if not hit anything then exit
            return;

        // if hit a sprite, color it
        ColorSprite(hit.collider);

        Debug.Log(hit.collider.name);

    }

    // Allow to raycast multiple sprites and color the one with the highest order in layer
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

        //Color it
        ColorSprite(highestCollider);
    }

    // Allow to color a sprite
    private void ColorSprite(Collider2D collider)
    {
        SpriteRenderer spriteRenderer = collider.GetComponent<SpriteRenderer>();

        //Ensure the GO has SpriteRenderer component
        if (spriteRenderer == null) return;

        // At this point the GO has SpriteRenderer component
        spriteRenderer.color = color;
    }
}
