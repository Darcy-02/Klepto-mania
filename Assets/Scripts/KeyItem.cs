using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public bool isCorrectKey = false;
    bool playerNear = false;

    public void Interact()
    {
        if (isCorrectKey)
        {
            Debug.Log("Correct Key!");
            // lock all others
            foreach (var k in Object.FindObjectsByType<KeyItem>())
            {
                k.enabled = false;
                var col = k.GetComponent<Collider2D>();
                if (col) col.enabled = false;
            }
            GameManager.I.CompleteTask(3);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Key");
            GameManager.I.WrongKey();
        }
    }

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNear = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) playerNear = false;
    }

    // also keep mouse for testing
    void OnMouseDown() { Interact(); }
}