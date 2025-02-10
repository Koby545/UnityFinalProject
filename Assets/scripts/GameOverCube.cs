using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCube : MonoBehaviour
{
    public GameObject gameOverUI; // Reference to the UI panel

    private GameTimer gameTimer;


    private void Start()
    {
        gameTimer = FindObjectOfType<GameTimer>(); // Find timer in the scene
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the player touched the cube
        {
            gameTimer.StopTimer();
            Debug.Log("Game Over! Player touched the cube.");
            EndGame();
        }
    }

    void EndGame()
    {
        gameOverUI.SetActive(true); // Show the Game Over UI
        Time.timeScale = 0f; // Pause the game
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
