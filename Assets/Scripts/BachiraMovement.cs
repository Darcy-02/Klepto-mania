using UnityEngine;

public class BachiraMovement : MonoBehaviour
{
    public float speed = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector2 lastDirection = Vector2.down;
    private Vector2 movement;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(x, y).normalized;

        if (movement.magnitude > 0)
        {
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

    void FixedUpdate()
    {
        // This respects colliders!
        rb.linearVelocity = movement * speed;
        // If your Unity is older, use: rb.velocity = movement * speed;
    }
}