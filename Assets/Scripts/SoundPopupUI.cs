using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundPopupUI : MonoBehaviour
{
    public static SoundPopupUI Instance;
    public GameObject panel;
    public AudioSource audioSource;
    public Button[] answerButtons; 

    SoundTrivia currentPuzzle;

    void Awake()
    {
        Instance = this;
        panel.SetActive(false);
        if (audioSource) audioSource.playOnAwake = false;
    }

    public void Show(SoundTrivia puzzle)
    {
        currentPuzzle = puzzle;
        panel.SetActive(true);
        Time.timeScale = 0f;

        audioSource.clip = puzzle.songToGuess;
        audioSource.Play();


        foreach (var btn in answerButtons)
        {
            btn.onClick.RemoveAllListeners();
            string nameOnButton = btn.GetComponentInChildren<TextMeshProUGUI>().text;
            btn.onClick.AddListener(() => Pick(nameOnButton));
        }
    }

    void Pick(string name)
    {
        currentPuzzle.CheckAnswer(name);
        audioSource.Stop();
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}