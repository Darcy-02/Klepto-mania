using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Puzzle Order")]
    // The exact order tasks must be completed in.
    // Must match the string each puzzle script passes into CompleteTask().
    public List<string> taskOrder = new List<string> { "Candles", "Keys", "ducks", "Sound", "Code" };
    List<string> doneTasks = new List<string>();

    [Header("UI - Step Instructions")]
    public TextMeshProUGUI stepText;
    public List<string> stepMessages = new List<string>
{
    "Step 1: Light all the candles (press E)",
    "Step 2: Pick the key that has purple (press E)",
    "Step 3: Pick the blue duck (press B)",
    "Step 4: Which song is this? (press E)",
    "Step 5: Enter the code on the door (press Space)"
};

    [Header("UI - Lose")]
    public GameObject losePanel;
    public TextMeshProUGUI loseMessageText;

    [Header("UI")]
    public TextMeshProUGUI progressText;   
    public Slider progressBar;             

    [Header("Door")]
    public LockDoor door;                  

    [Header("Win")]
    public GameObject winPanel;
    

    int trials = 0;
    const int maxTrials = 3;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        doneTasks.Clear();
        if (progressBar != null) progressBar.maxValue = taskOrder.Count;
        UpdateUI();
    }

    public bool CompleteTask(string taskName)
    {
        if (doneTasks.Contains(taskName)) return true;

        string expected = taskOrder[doneTasks.Count];
        if (taskName != expected)
        {
            Debug.LogWarning($"'{taskName}' triggered out of order - expected '{expected}' next. Ignored.");
            return false;
        }

        doneTasks.Add(taskName);
        UpdateUI();
        ResetTrials();

        if (doneTasks.Count >= taskOrder.Count)
        {
            if (door != null) door.UnlockDoor();
            Win();
        }
        return true;
    }

    void UpdateUI()
    {
        if (progressText != null)
            progressText.text = $"Puzzle Progress: {doneTasks.Count} / {taskOrder.Count}";
        if (progressBar != null)
            progressBar.value = doneTasks.Count;
        if (stepText != null)
        {
            if (doneTasks.Count < stepMessages.Count)
                stepText.text = stepMessages[doneTasks.Count];
            else
                stepText.text = "All steps complete!";
        }
    }

    public void Win()
    {
        Time.timeScale = 0f;
        if (winPanel != null) winPanel.SetActive(true);
    }

    public void Lose(string reason)
    {
        Time.timeScale = 0f;
        if (losePanel != null) losePanel.SetActive(true);
        if (loseMessageText != null) loseMessageText.text = "YOU LOST\n" + reason;
        Debug.Log("LOST: " + reason);
        StartCoroutine(RestartAfter(2.5f));
    }

    IEnumerator RestartAfter(float sec)
    {
        yield return new WaitForSecondsRealtime(sec); 
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ResetTrials() { trials = 0; }

    public void WrongDuck() { WrongGeneric("Wrong duck"); }
    public void WrongKey() { WrongGeneric("Wrong key"); }
    public void WrongSound() { WrongGeneric("Wrong song"); }

    void WrongGeneric(string reason)
    {
        trials++;
        Debug.Log($"{reason}! {trials}/{maxTrials}");
        if (trials >= maxTrials) Lose(reason + "");
    }
}