using System.Collections;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.Android;

public class CaptureManager : MonoBehaviour
{
    public Camera captureCamera; // Camera used to capture GameObject Paper
    public Transform paperObject;
    private int imageWidth;
    private int imageHeight;

    private void Start()
    {
        // Request write permission on Android
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
            {
                Permission.RequestUserPermission(Permission.ExternalStorageWrite);
            }
        }

        // Get the width and height of the paperObject
        imageWidth = (int)paperObject.GetComponent<RectTransform>().rect.width;
        imageHeight = (int)paperObject.GetComponent<RectTransform>().rect.height;
    }

    public void CaptureAndSaveImage()
    {
        StartCoroutine(CaptureScreenshot());
    }

    private IEnumerator CaptureScreenshot()
    {
        // Create RenderTexture
        RenderTexture renderTexture = new RenderTexture(imageWidth, imageHeight, 24);
        captureCamera.targetTexture = renderTexture;
        yield return new WaitForEndOfFrame();

        // Capture image from Camera
        Texture2D screenshot = new Texture2D(imageWidth, imageHeight, TextureFormat.RGB24, false);
        captureCamera.Render();
        RenderTexture.active = renderTexture;
        screenshot.ReadPixels(new Rect(0, 0, imageWidth, imageHeight), 0, 0);
        screenshot.Apply();

        // Reset Camera
        captureCamera.targetTexture = null;
        RenderTexture.active = null;
        Destroy(renderTexture);

        // Save image to gallery
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
    }
}
