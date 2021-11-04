using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Loads the game scene
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Go to the main menu
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }

    // Quit the game (No use cause it's a WebGL build but still keeping for future reference)
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Restart the game
    public void resetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
