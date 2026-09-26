using UnityEngine;

public class CandlePuzzle : MonoBehaviour
{
    public int totalToLight = 4;
    int litCount = 0;
    bool done = false;

    public void CandleLit()
    {
        litCount++;
        Debug.Log("Candles: " + litCount + "/" + totalToLight);
        if (!done && litCount >= totalToLight)
        {
            done = true;
            GameManager.Instance.CompleteTask("Candles");
        }
    }
}