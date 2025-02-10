using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{

    public Text bestTimeText; // Reference to the Best Time UI

    void Start()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        if (bestTime > 0)
        {
            int minutes = Mathf.FloorToInt(bestTime / 60);
            int seconds = Mathf.FloorToInt(bestTime % 60);
            int milliseconds = Mathf.FloorToInt((bestTime * 100) % 100);
            bestTimeText.text = $"Best Time: {minutes:00}:{seconds:00}:{milliseconds:00}";
        }
        else
        {
            bestTimeText.text = "Best Time: N/A";
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("scene1"); // Change "GameScene" to your actual game scene name
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
#elif UNITY_WEBGL
        GameObject blackScreen = new GameObject("BlackScreen");
        blackScreen.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        Image blackImage = blackScreen.AddComponent<Image>();
        blackImage.color = Color.black; // Make the screen black
#else
        Application.Quit(); // Quit the standalone build (exe)
#endif

        Debug.Log("Game Quit!"); // Debug message for testing
    }
}
