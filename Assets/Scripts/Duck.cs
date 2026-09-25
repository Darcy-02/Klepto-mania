using UnityEngine;

public class Duck : MonoBehaviour
{
    public bool isBlueDuck = false;
    bool playerNear = false;

    public void Interact()
    {
        if (isBlueDuck)
        {
            Debug.Log("Correct Blue Duck!");
            foreach (var d in Object.FindObjectsByType<Duck>())
            {
                d.enabled = false;
                var col = d.GetComponent<Collider2D>();
                if (col) col.enabled = false;
            }
            GameManager.I.CompleteTask(4);
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Duck");
            GameManager.I.WrongDuck();
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

    void OnMouseDown() { Interact(); }
}