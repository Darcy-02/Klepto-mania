using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Interactable nearby; 
    Duck nearbyDuck;     

    void Update()
    {
        
        if (nearby != null && Input.GetKeyDown(KeyCode.E))
        {
            nearby.Interact();
        }


        if (nearbyDuck != null && Input.GetKeyDown(KeyCode.B))
        {
            nearbyDuck.Interact();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        var d = col.GetComponent<Duck>();
        if (d != null)
        {
            nearbyDuck = d;
            Debug.Log("Near duck: " + d.name + " - press B");
            return;
        }

     
        var i = col.GetComponent<Interactable>();
        if (i != null)
        {
            nearby = i;
            Debug.Log("Near object: " + i.name + " - press E");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Duck>() == nearbyDuck) nearbyDuck = null;
        if (col.GetComponent<Interactable>() == nearby) nearby = null;
    }
}