using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Back button -> Main Menu
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Next button starts the game
    public void StartGame()
    {
        SceneManager.LoadScene("GameArea1");
    }
}