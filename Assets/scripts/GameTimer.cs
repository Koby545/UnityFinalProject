using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Text timerText;  // UI Text to display the timer
    public bool timerRunning = false;  // Track if the timer has started

    private float elapsedTime = 0f;  // Time counter
    private bool gameFinished = false;  // Check if game has ended

    void Update()
    {
        if (!gameFinished && timerRunning)  // Update timer only if game is running
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    public void StartTimer()
    {
        if (!timerRunning)  // Start the timer when player moves
        {
            timerRunning = true;
        }
    }

    public void StopTimer()
    {
        gameFinished = true;
        timerRunning = false;

        // Save the best time if it's a new record
        float bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        if (elapsedTime < bestTime)
        {
            PlayerPrefs.SetFloat("BestTime", elapsedTime);
            PlayerPrefs.Save();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
        timerText.text = $"{minutes:00}:{seconds:00}:{milliseconds:00}";
    }
}
