using UnityEngine;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [Header("Puzzle")]
    public int totalTasks = 5;
    public int completedTasks = 0;

    [Header("UI")]
    public TextMeshProUGUI progressText;

    [Header("Door")]
    public LockDoor door;

    void Awake() { Instance = this; }

    void Start() { UpdateUI(); }

    public void CompleteTask(string taskName)
    {
        completedTasks++;
        Debug.Log("Task Complete: " + taskName + " - " + completedTasks + "/" + totalTasks);
        UpdateUI();

        if (completedTasks >= totalTasks)
        {
            door.UnlockDoor();
        }
    }

    void UpdateUI()
    {
        if (progressText != null)
            progressText.text = "Puzzle Progress: " + completedTasks + " / " + totalTasks;
    }
}
