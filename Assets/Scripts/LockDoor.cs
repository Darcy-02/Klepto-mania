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
        if (sr != null) sr.color = Color.red; 
    }

    public void UnlockDoor()
    {
        isLocked = false;
        if (sr != null) sr.color = Color.green; 
        if (col != null) col.enabled = false; 
        Debug.Log("DOOR UNLOCKED! You can escape!");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isLocked && other.CompareTag("Player"))
        {
            Debug.Log("WIN! Player Escaped!");
            
        }
    }
}
