using System.Collections;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;

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
    public float crouchHeightAdjustment = 0.01f;   // How much to lift the player when crouching

    public bool isCrouching = false;
    public bool isFlipping = false;

    void Start()
    {
        GroundLayer = LayerMask.GetMask("Ground");
        WallLayer = LayerMask.GetMask("Wall");


    }
    void Update()
    {

        float moveInput = UnityEngine.Input.GetAxis("Horizontal");

        Move(moveInput);

        Jump(moveInput);

        Crouch();



        //set animator prefrences
        //anim.SetBool("run", moveInput != 0);
        //anim.SetBool("Grounded", isGrounded());

    }


    void Move(float moveInput)
    {
        if (isCrouching || isFlipping)
        {
            // Do not move when crouching or flipping
            return;
        }



        Body.velocity = new Vector2(moveInput * playerStats.moveSpeed, Body.velocity.y);

        if (moveInput >= 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (moveInput <= -0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
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

                // gun direction + position fix
                UnityEngine.Transform Guntransform = transform.Find("Gun");
                Debug.Log(Guntransform.position);
                Debug.Log(Guntransform.localPosition);
                Guntransform.position = new Vector3(0.204f, -0.024f, Guntransform.position.z);
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
                Body.gravityScale = 9.8f; // You might need to adjust this value to your original gravity scale

                // gun direction + position fix
                UnityEngine.Transform Guntransform = transform.Find("Gun");
                Debug.Log(Guntransform.position);
                Debug.Log(Guntransform.localPosition);
                Guntransform.position = new Vector3(0.122f, Guntransform.position.y, Guntransform.position.z);
            }
        }
    }

    void Jump(float moveInput)
    {

        //anim.SetTrigger("jump");

        //wall jump logic
        if (wallJumpCoolDown < 0.2f)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space) && isGrounded())
            {
                Body.velocity = new Vector2(Body.velocity.x, playerStats.jumpForce);
                StartCoroutine(Flip());
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
