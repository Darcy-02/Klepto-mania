using UnityEngine;

public class Candle : MonoBehaviour
{
    bool isLit = false;
    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr) sr.color = new Color(0.35f, 0.35f, 0.35f, 1f);
    }

    public void TryLight()
    {
        if (isLit) return;
        isLit = true;
        if (sr) sr.color = new Color(1f, 0.9f, 0.4f, 1f);
        transform.localScale *= 1.1f;
        Object.FindAnyObjectByType<CandlePuzzle>().CandleLit();
    }
}
