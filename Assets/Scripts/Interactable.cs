using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact()
    {
        
        var candle = GetComponent<Candle>();
        if (candle != null) candle.TryLight();
    }
}
