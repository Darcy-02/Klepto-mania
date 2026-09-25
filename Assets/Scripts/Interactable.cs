using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        // If it's a candle, light it
        var candle = GetComponent<Candle>();
        if (candle != null) candle.TryLight();
    }
}
