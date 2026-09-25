using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance;

    [Header("Puzzle")]
    public int totalTasks = 5;
    public int completedTasks = 0;
    List<string> doneTasks = new List<string>(); 

    [Header("UI")]
    public TextMeshProUGUI Progress;

    [Header("Door")]
    public LockDoor door; 

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        completedTasks = 0;
        UpdateUI();
    }

    public void CompleteTask(string taskName)
    {
        if (doneTasks.Contains(taskName)) return; 
        doneTasks.Add(taskName);

        completedTasks++;
        Debug.Log("Task Complete: " + taskName + " - " + completedTasks + "/" + totalTasks);
        UpdateUI();

        if (completedTasks >= totalTasks)
        {
            if (door != null) door.UnlockDoor();
            else Debug.Log("ALL PUZZLES DONE - Door would unlock now!");
        }
    }

    void UpdateUI()
    {
        if (Progress != null)
            Progress.text = "Puzzle Progress: " + completedTasks + " / " + totalTasks;
    }
}