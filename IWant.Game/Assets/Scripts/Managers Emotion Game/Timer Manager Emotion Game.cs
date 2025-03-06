using System;
using UnityEngine;

public class TimeManagerEmotionGame : MonoBehaviour
{
    public static TimeManagerEmotionGame instance;

    private float elapsedTime;
    private bool isRunning = false;

    public event Action<float> OnTimeUpdate;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
            OnTimeUpdate?.Invoke(elapsedTime);
            // Debug.Log("Elapsed Time: " + elapsedTime);
        }
    }
    public void ResetTimer()
    {
        elapsedTime = 0;  // Đưa thời gian về 0
        isRunning = false; // Tạm dừng bộ đếm
        Debug.Log("Timer reset");
    }
    public void StartTimer()
    {
        elapsedTime = 0;
        isRunning = true;
        Debug.Log("Timer started");
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("Timer stopped");
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
