using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject player; // ADD THIS

    void Start()
    {
        if (startMenu != null)
        {
            startMenu.SetActive(true);
        }

        // Disable player at start
        if (player != null)
        {
            player.SetActive(false);
        }

        Time.timeScale = 1f; // keep normal so UI/animations work
    }

    public void StartGame()
    {
        if (startMenu != null)
        {
            startMenu.SetActive(false);
        }

        // Enable player when game starts
        if (player != null)
        {
            player.SetActive(true);
        }

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}