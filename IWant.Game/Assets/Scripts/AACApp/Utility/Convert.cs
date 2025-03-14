using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public static class Convert
{
    // Allow to convert a byte array to a Sprite
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

    public static Sprite ConvertToSprite(Texture2D texture)
    {
        return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
    }

    public static IEnumerator LoadImage(string imagePath, System.Action<Sprite> callback)
    {
        using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(AddressAPI.BASE_URL + $"/{imagePath}"))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(request);
                Sprite sprite = ConvertToSprite(texture);

                float delay = Random.Range(0.3f, 0.5f);
                yield return new WaitForSeconds(delay);
                callback(sprite);
            }
            else
            {
                Debug.LogError("Failed to load image: " + request.error);
                callback?.Invoke(null);
            }
        }
    }
}
