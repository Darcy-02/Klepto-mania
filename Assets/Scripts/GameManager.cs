using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager I;
    public static GameManager Instance { get { return I; } } // fix your Instance error

    public Slider progressBar;
    public TMP_Text progressText;
    public GameObject doorClosed, doorOpen;
    public GameObject losePanel, winPanel;

    int collected = 0;
    int trials = 0;

    void Awake() { I = this; }

    void Start()
    {
        if(progressBar) { progressBar.maxValue = 5; progressBar.value = 0; }
        UpdateUI();
        if(doorClosed) doorClosed.SetActive(true);
        if(doorOpen) doorOpen.SetActive(false);
    }

    void UpdateUI()
    {
        if(progressBar) progressBar.value = collected;
        if(progressText) progressText.text = $"{collected}/5";
    }

    // NEW SYSTEM
    public void CompleteTask(int taskNum)
    {
        collected = Mathf.Max(collected, taskNum);
        UpdateUI();
        ResetTrials();

        if(collected == 4)
        {
            if(doorClosed) doorClosed.SetActive(false);
            if(doorOpen) doorOpen.SetActive(true);
        }
        if(collected >= 5)
        {
            doorClosed.SetActive(false);
            doorOpen.SetActive(false);
            Win();
        }
        else
        {
            if(PlayerSteps.I != null) PlayerSteps.I.ShowStep(collected + 1);
        }
    }

    public void Win() { Time.timeScale = 0f; if(winPanel) winPanel.SetActive(true); }
    public void Lose() { Time.timeScale = 0f; if(losePanel) losePanel.SetActive(true); }

    // --- FIX FOR YOUR OLD SCRIPTS (so errors disappear) ---
    public void ResetTrials() { trials = 0; }

    public void WrongDuck() { WrongGeneric(); }
    public void WrongKey() { WrongGeneric(); }
    public void WrongSound() { WrongGeneric(); }

    void WrongGeneric()
    {
        trials++;
        Debug.Log("Wrong! " + trials + "/3");
        if(trials >= 3) Lose();
    }
}