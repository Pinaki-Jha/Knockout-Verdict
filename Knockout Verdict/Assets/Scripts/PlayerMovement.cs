using System.Collections;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D Body;
    public BoxCollider2D boxCollider;
    public StatSystemScript playerStats;    //Shifted moveSpeed and jumpForce to playerStats
    public Animator anim;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask WallLayer;

    private float wallJumpCoolDown;
    public float flipDuration = 0.3f;   //flip time
    public float crouchHeightAdjustment = 0.001f;   // How much to lift the player when crouching

    public bool isCrouching = false;
    public bool isFlipping = false;


    void Update()
    {

        if (isCrouching || isFlipping)
        {
            // Do not move when crouching or flipping
            return;
        }
        
        float moveInput = UnityEngine.Input.GetAxis("Horizontal");
        

        //flip player according to direction of movement
        if (moveInput >= 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (moveInput <= -0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }


        //wall jump logic
        if (wallJumpCoolDown < 0.2f)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                Jump();
            }
            Body.velocity = new Vector2(moveInput * playerStats.moveSpeed, Body.velocity.y);

            if (onWall() && !isGrounded())
            {
                Body.gravityScale = 25;
            }
            else
            {
                Body.gravityScale = 9.8f;
            }
        }
        else
        {
            wallJumpCoolDown = Time.deltaTime;
        }

        //set animator prefrences
        anim.SetBool("run", moveInput != 0);
        anim.SetBool("Grounded", isGrounded());

        if (UnityEngine.Input.GetKey(KeyCode.C) && UnityEngine.Input.GetAxis("Horizontal") == 0)
        {
            Crouch();
        }
    }

    
    
    void Crouch()
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

        else
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

    void Jump()
    {
        Body.velocity = new Vector2(Body.velocity.x, playerStats.jumpForce);
        anim.SetTrigger("jump");


        StartCoroutine(Flip());
    
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

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, GroundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, WallLayer);
        return raycastHit.collider != null;
    }
}