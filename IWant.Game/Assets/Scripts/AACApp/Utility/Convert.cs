using UnityEngine;

public static class Convert
{
    public static Sprite ConvertBytesToSprite(byte[] imageBytes)
    {
        Texture2D texture = new Texture2D(2, 2); // Placeholder size, will resize automatically
        if (texture.LoadImage(imageBytes))
        {
            return Sprite.Create(
                texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f)
            );
        }
        else
        {
            Debug.LogWarning("Failed to load texture from byte array.");
            return null;
        }
    }
}
