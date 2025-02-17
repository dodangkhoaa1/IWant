using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Android;
using EasyUI.Toast;

public class CaptureManager : MonoBehaviour
{
    public Camera captureCamera; // Camera used to capture GameObject Paper
    public Transform paperObject;

[Header("Watermark Settings")]
    public Sprite waterMark;
    [SerializeField] float alphaScale = 0.3f; // Độ trong suốt của watermark (1.0 = không trong suốt, 0.0 = hoàn toàn trong suốt)
    [SerializeField] int percentOfWatermark = 30;

    private int imageWidth = 1920;
    private int imageHeight = 1080;


    private void Start()
    {

    }

    public void CaptureAndSaveImage()
    {
        // Request write permission on Android
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
        }
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // 1) Tạo RenderTexture
        RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
        captureCamera.targetTexture = renderTexture;
        yield return new WaitForEndOfFrame(); // đảm bảo frame đã render xong

        // 2) Lấy RectTransform của UI "Paper"
        RectTransform paperRect = paperObject.GetComponent<RectTransform>();
        if (paperRect == null)
        {
            Debug.LogError("paperObject không có RectTransform!");
            yield break;
        }

        // Lấy 4 góc trong thế giới
        Vector3[] corners = new Vector3[4];
        paperRect.GetWorldCorners(corners);

        // Tính min/max trong Viewport
        float minU = float.MaxValue, minV = float.MaxValue;
        float maxU = float.MinValue, maxV = float.MinValue;

        for (int i = 0; i < 4; i++)
        {
            Vector3 viewPos = captureCamera.WorldToViewportPoint(corners[i]);
            if (viewPos.x < minU) minU = viewPos.x;
            if (viewPos.y < minV) minV = viewPos.y;
            if (viewPos.x > maxU) maxU = viewPos.x;
            if (viewPos.y > maxV) maxV = viewPos.y;
        }

        // Clamp để chắc chắn nằm trong [0..1]
        minU = Mathf.Clamp01(minU);
        minV = Mathf.Clamp01(minV);
        maxU = Mathf.Clamp01(maxU);
        maxV = Mathf.Clamp01(maxV);

        float rectX = minU * imageWidth;
        float rectY = minV * imageHeight;
        float rectW = (maxU - minU) * imageWidth;
        float rectH = (maxV - minV) * imageHeight;

        // 3) Render camera
        captureCamera.Render();

        // 4) Tạo Texture2D cho vùng crop
        if (rectW <= 0 || rectH <= 0)
        {
            Debug.LogWarning("UI nằm ngoài khung hình camera hoặc bounding box = 0!");
            yield break;
        }
        Texture2D screenshot = new Texture2D((int)rectW, (int)rectH, TextureFormat.RGB24, false);

        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(rectX, rectY, rectW, rectH), 0, 0);
        screenshot.Apply();

        // 5) Reset
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        //6 them water mark
        if (waterMark != null)
        {
            Texture2D watermarkTex = SpriteToTexture2D(waterMark);
            screenshot = AddWatermark(screenshot, watermarkTex);
        }
        // 7) Lưu ảnh
        SaveImageToGallery(screenshot);
    }
    private void SaveImageToGallery(Texture2D image)
    {
        string filename = "PaperScreenshot_" + System.DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        string filePath = Path.Combine(Application.persistentDataPath, filename);
        File.WriteAllBytes(filePath, image.EncodeToPNG());

        // Save to gallery
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(filePath, "ColoringGame", filename);
        Debug.Log("Save result: " + permission);

        // Lưu trên laptop (chỉ khi chạy trên PC)
#if UNITY_EDITOR || UNITY_STANDALONE
        string customPath = @"C:\Users\dodan\Pictures\ExportImageColoring"; // Thư mục đích
        if (!Directory.Exists(customPath))
        {
            Directory.CreateDirectory(customPath); // Tạo thư mục nếu chưa tồn tại
        }

        string savePath = Path.Combine(customPath, filename);
        File.WriteAllBytes(savePath, image.EncodeToPNG());
        Debug.Log("Image saved to: " + savePath);
#endif
        Toast.Show("Save successfully!", 1.5f, ToastColor.Green, ToastPosition.BottomCenter);
    }

    private Texture2D SpriteToTexture2D(Sprite sprite)
    {
        Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        Color[] pixels = sprite.texture.GetPixels((int)sprite.rect.x, (int)sprite.rect.y, (int)sprite.rect.width, (int)sprite.rect.height);
        texture.SetPixels(pixels);
        texture.Apply();
        return texture;
    }
    private Texture2D AddWatermark(Texture2D baseImage, Texture2D watermark)
    {
        int margin = 20; // Khoảng cách từ góc dưới phải
       

        // Tính toán kích thước watermark dựa trên chiều rộng 20% ảnh đã cắt
        int newWidth = baseImage.width * percentOfWatermark / 100; // 20% của ảnh gốc
        float aspectRatio = (float)watermark.height / watermark.width; // Giữ nguyên tỷ lệ
        int newHeight = Mathf.RoundToInt(newWidth * aspectRatio); // Tính chiều cao dựa vào tỷ lệ

        // Resize watermark
        Texture2D resizedWatermark = ResizeTexture(watermark, newWidth, newHeight);

        // Vị trí góc dưới phải
        int posX = baseImage.width - newWidth - margin;
        int posY = margin;

        Color[] watermarkPixels = resizedWatermark.GetPixels();
        Color[] basePixels = baseImage.GetPixels(posX, posY, newWidth, newHeight);

        for (int i = 0; i < watermarkPixels.Length; i++)
        {
            Color wmColor = watermarkPixels[i];
            if (wmColor.a > 0.1f) // Chỉ áp dụng pixel có alpha > 0.1
            {
                wmColor.a *= alphaScale; // Giảm độ đậm của watermark
                basePixels[i] = Color.Lerp(basePixels[i], wmColor, wmColor.a);
            }
        }

        baseImage.SetPixels(posX, posY, newWidth, newHeight, basePixels);
        baseImage.Apply();
        return baseImage;
    }


    private Texture2D ResizeTexture(Texture2D source, int newWidth, int newHeight)
    {
        RenderTexture rt = new RenderTexture(newWidth, newHeight, 24);
        RenderTexture.active = rt;

        Graphics.Blit(source, rt);
        Texture2D result = new Texture2D(newWidth, newHeight, TextureFormat.RGBA32, false);
        result.ReadPixels(new Rect(0, 0, newWidth, newHeight), 0, 0);
        result.Apply();

        RenderTexture.active = null;
        rt.Release();
        return result;
    }


}