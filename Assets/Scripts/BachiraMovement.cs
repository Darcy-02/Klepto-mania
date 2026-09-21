using UnityEngine;

public class BachiraMovement : MonoBehaviour
{
    public float speed = 5f;

    private Animator animator;

    private Vector2 lastDirection = Vector2.down; // default facing front

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(x, y).normalized;

        if (movement.magnitude > 0)
        {
            transform.position += (Vector3)movement * speed * Time.deltaTime;

            lastDirection = movement;

            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        animator.SetFloat("moveX", lastDirection.x);
        animator.SetFloat("moveY", lastDirection.y);
    }
}