using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Body;
    public BoxCollider2D boxCollider;
    public StatSystemScript playerStats;    //Shifted moveSpeed and jumpForce to playerStats

    public float flipDuration = 0.3f; //flip time
    public float crouchHeightAdjustment = 0.001f; // How much to lift the player when crouching

    public bool isGrounded = true;
    public bool isCrouching = false;
    public bool isFlipping = false;

    void Update()
    {
            Move();
            Crouch();
            Jump();
    }

    void Move()
    {
        if (isCrouching || isFlipping)
        {
            // Do not move when crouching or flipping
            return;
        }

        float moveInput = UnityEngine.Input.GetAxis("Horizontal");

        Body.velocity = new Vector2(moveInput * playerStats.moveSpeed, Body.velocity.y);

        if (moveInput >= 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if ( moveInput <= -0.01f)
        {
            transform.rotation = Quaternion.Euler(0f,180f, 0f);
        }
    }

    
    void Crouch()
    {
        if (UnityEngine.Input.GetKey(KeyCode.C) && UnityEngine.Input.GetAxis("Horizontal") == 0)
        {
            if (!isCrouching)
            {
                // Set the collider size to the crouch rotation
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, -90);
                isCrouching = true;
                // Lift the player up a little bit
                transform.position = new Vector3(transform.position.x, transform.position.y + crouchHeightAdjustment, transform.position.z);
                // Disable gravity
                Body.gravityScale = 0;
            }

        }
        else
        {
            if (isCrouching)
            {
                // Revert the collider rotation to the original orientation
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
                isCrouching = false;
                // Lower the player back to the original position
                transform.position = new Vector3(transform.position.x, transform.position.y - crouchHeightAdjustment, transform.position.z);
                // Re-enable gravity
                Body.gravityScale = 9.8f;
            }
        }
    }

    void Jump()
    {
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCrouching)
        {
            Body.velocity = new Vector2(Body.velocity.x, playerStats.jumpForce);
            StartCoroutine(Flip());
        }
    }


    private IEnumerator Flip()
    {
        isFlipping = true;
        float elapsedTime = 0;
        while (elapsedTime < flipDuration)
        {
            float zRotation = Mathf.Lerp(0, -360, elapsedTime / flipDuration);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, zRotation);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        isFlipping = false;

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