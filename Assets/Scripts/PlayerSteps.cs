using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerSteps : MonoBehaviour
{
    public static PlayerSteps I;
    public TMP_Text label;
    public Transform player;
    public float showDuration = 5f;

    string[] steps = {
        "Step 1: Light all candles",
        "Step 2: Press E to listen to songs being played behind the door and choose which it is",
        "Step 3: Pick the correct key",
        "Step 4: Pick the BLUE duck",
        "Step 5: Solve the door puzzle",
        "YOU WIN! Door open!"
    };

    void Awake() { I = this; }
    void Start() { ShowStep(1); }
    void Update() { if (player) label.transform.position = player.position + Vector3.up * 1.8f; }

    public void ShowStep(int n)
    {
        StopAllCoroutines();
        label.text = steps[Mathf.Clamp(n - 1, 0, 5)];
        label.alpha = 1f;
        label.gameObject.SetActive(true);
        if (n != 6) StartCoroutine(Fade());
    }
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(showDuration);
        for (float t = 0; t < 1f; t += Time.deltaTime)
        {
            label.alpha = Mathf.Lerp(1f, 0f, t);
            yield return null;
        }
        label.gameObject.SetActive(false);
        label.alpha = 1f;
    }
}