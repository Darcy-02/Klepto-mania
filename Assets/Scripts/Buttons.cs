using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoNext()
    {
        SceneManager.LoadScene("GameArea1");
    }
}