using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D Body;
    private Vector2 originalColliderSize;
    private Vector2 crouchColliderSize;
    public BoxCollider2D boxCollider;
    public float MoveSpeed = 5;
    public float jumpForce = 10;
    public bool isGrounded = true;
    public bool isCrouching = false;

    void Start()
    {
        // Save the original collider size
        originalColliderSize = boxCollider.size;
        // Set a new collider size for crouching
        crouchColliderSize = new Vector2(boxCollider.size.x, boxCollider.size.y / 2);
    }

    void Update()
    {
        Move();
        Crouch();
        Jump();

    }

    void Move()
    {
        float moveInput = UnityEngine.Input.GetAxis("Horizontal");

        Body.velocity = new Vector2(moveInput * MoveSpeed, Body.velocity.y);

        if (moveInput >= 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if ( moveInput <= -0.01f)
        {
            transform.rotation = Quaternion.Euler(0f,180f, 0f);
        }

    }

    void Flip()
    {

        
    }

    void Crouch()
    {
        if (UnityEngine.Input.GetKey(KeyCode.S) && UnityEngine.Input.GetAxis("Horizontal") == 0)
        {
            if (!isCrouching)
            {
                // Set the collider size to the crouch size
                boxCollider.size = crouchColliderSize;
                isCrouching = true;
                // Additional actions like changing animation to crouching
            }
        }
        else
        {
            if (isCrouching)
            {
                // Revert the collider size to the original size
                boxCollider.size = originalColliderSize;
                isCrouching = false;
                // Additional actions like changing animation back to standing
            }
        }
    }

    void Jump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            Body.velocity = new Vector2(Body.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if player is on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Check if player is no longer on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}