using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Puzzle Order")]
    // The exact order tasks must be completed in.
    // Must match the string each puzzle script passes into CompleteTask().
    public List<string> taskOrder = new List<string> { "Candles", "Keys", "ducks", "Sound", "Code" };
    List<string> doneTasks = new List<string>();

    [Header("UI")]
    public TextMeshProUGUI progressText;   // "Puzzle Progress: x / 5"
    public Slider progressBar;             // optional, leave empty if unused

    [Header("Door")]
    public LockDoor door;                  // your existing single-door script

    [Header("Win / Lose")]
    public GameObject winPanel;
    public GameObject losePanel;

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
    }

    public void Win()
    {
        Time.timeScale = 0f;
        if (winPanel != null) winPanel.SetActive(true);
    }

    public void Lose(string reason = "")
    {
        Time.timeScale = 0f;
        if (losePanel != null) losePanel.SetActive(true);
        Debug.Log("LOST: " + reason);
    }

    public void ResetTrials() { trials = 0; }

    public void WrongDuck() { WrongGeneric("Wrong duck"); }
    public void WrongKey() { WrongGeneric("Wrong key"); }
    public void WrongSound() { WrongGeneric("Wrong song"); }

    void WrongGeneric(string reason)
    {
        trials++;
        Debug.Log($"{reason}! {trials}/{maxTrials}");
        if (trials >= maxTrials) Lose(reason + " x3");
    }
}