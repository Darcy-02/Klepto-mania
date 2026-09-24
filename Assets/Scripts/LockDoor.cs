using UnityEngine;

public class LockDoor : MonoBehaviour
{
    public bool isLocked = true;
    private BoxCollider2D col;
    private SpriteRenderer sr;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.color = Color.red; // Locked = red
    }

    public void UnlockDoor()
    {
        isLocked = false;
        if (sr != null) sr.color = Color.green; // Unlocked = green
        if (col != null) col.enabled = false; // Player can now walk through
        Debug.Log("DOOR UNLOCKED! You can escape!");
        // Add sound / animation here
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            Debug.Log("WIN! Player Escaped!");
            // You can load win screen here later
        }
    }
}
