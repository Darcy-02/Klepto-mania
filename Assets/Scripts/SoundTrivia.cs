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
            done = true;
            GameManager.Instance.ResetTrials();
            PuzzleManager.Instance.CompleteTask(puzzleID);
            Debug.Log("CORRECT!");
        }
        else
        {
            Debug.Log($"WRONG! Picked {pickedName}");
            GameManager.Instance.WrongSound();
        }
    }
}