using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        // Load the level
        SceneManager.LoadScene(1);
    }

    public void QuitButton()
    {
        // Quit the game when we press the quit button
        Application.Quit();
    }
}
