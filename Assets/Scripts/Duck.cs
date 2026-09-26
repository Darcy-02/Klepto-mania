using UnityEngine;

public class Duck : MonoBehaviour
{
    public bool isBlueDuck = false;

    public void Interact()
    {
        if (isBlueDuck)
        {
            Debug.Log("Correct Blue Duck!");
            foreach (var d in Object.FindObjectsByType<Duck>(FindObjectsSortMode.None))
            {
                d.enabled = false;
                var col = d.GetComponent<Collider2D>();
                if (col) col.enabled = false;
            }
            GameManager.Instance.CompleteTask("ducks");
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Wrong Duck");
            GameManager.Instance.WrongDuck();
        }
    }
}