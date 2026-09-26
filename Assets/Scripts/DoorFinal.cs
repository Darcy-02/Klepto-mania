using UnityEngine;
using TMPro;

public class DoorFinal : MonoBehaviour
{
    [Header("Drag here")]
    public GameObject puzzlePanel;
    public TMP_InputField input;

    bool nearDoor = false;
    bool solved = false;

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
            bool accepted = GameManager.Instance.CompleteTask("Code");
            if (accepted)
            {
                solved = true;
                Time.timeScale = 1f;
                puzzlePanel.SetActive(false);
            }
            else
            {
                Debug.Log("Correct code, but solve the earlier puzzles first.");
                input.text = "";
            }
        }
        else
        {
            GameManager.Instance.WrongKey();
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