using UnityEngine;
using TMPro;

public class DoorFinal : MonoBehaviour
{
    [Header("Drag here")]
    public GameObject puzzlePanel;
    public TMP_InputField input;

    bool nearDoor = false;

    void Update()
    {
        if (nearDoor && Input.GetKeyDown(KeyCode.Space))
        {
            puzzlePanel.SetActive(true);
            Time.timeScale = 0f;
        }

        if (puzzlePanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }

    public void CheckAnswer()
    {
        if (input.text == "11122111")
        {
            Debug.Log("WIN!");
            Time.timeScale = 1f;
            puzzlePanel.SetActive(false);
            // win here
        }
        else
        {
            input.text = "";
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        nearDoor = true;
    }
    void OnTriggerExit2D(Collider2D col)
    {
        nearDoor = false;
    }
}