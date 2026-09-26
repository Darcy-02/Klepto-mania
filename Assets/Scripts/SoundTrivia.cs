using UnityEngine;

public class SoundTrivia : Interactable
{
    public string puzzleID = "Sound";
    public AudioClip songToGuess;
    public string correctAnswer = "Beauty and the Beast";
    bool done = false;

    public override void Interact()
    {
        if (done) return;
        SoundPopupUI.Instance.Show(this);
    }

    public void CheckAnswer(string pickedName)
    {
        if (pickedName == correctAnswer)
        {
            bool accepted = GameManager.Instance.CompleteTask(puzzleID);
            if (accepted)
            {
                done = true;
                Debug.Log("CORRECT!");
            }
            else
            {
                Debug.Log("Correct, but solve the earlier puzzle first.");
            }
        }
        else
        {
            GameManager.Instance.WrongSound();
        }
    }
}