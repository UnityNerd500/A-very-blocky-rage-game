using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Public Variables
    [Header("Assignables")]
    public GameObject pauseMenu;

    // Private Variables
    private bool isPaused;

    private void Update()
    {
        // If the pause menu is active, isPaused is true
        if (pauseMenu.activeSelf)
            isPaused = true;

        // If the pause menu is not active, isPaused is false
        if (!pauseMenu.activeSelf)
            isPaused = false;

        // If the game is not paused and you press the 'escape' key, then pause
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;

            pauseMenu.SetActive(true);
        }

        // If the game is paused and you press the 'escape' key, then unpause
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;

            pauseMenu.SetActive(false);
        }
    }
}
