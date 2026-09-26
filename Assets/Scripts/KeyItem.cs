using UnityEngine;

public class KeyItem : Interactable
{
    public bool isCorrectKey = false;

    public override void Interact()
    {
        if (isCorrectKey)
        {
            Debug.Log("Correct Key!");
            foreach (var k in Object.FindObjectsByType<KeyItem>(FindObjectsSortMode.None))
            {
                k.enabled = false;
                var col = k.GetComponent<Collider2D>();
                if (col) col.enabled = false;
            }
            GameManager.Instance.CompleteTask("Keys");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Key");
            GameManager.Instance.WrongKey();
        }
    }
}