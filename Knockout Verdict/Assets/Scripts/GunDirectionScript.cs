using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GunDirectionScript : MonoBehaviour
{
    private float xInput;
    private int facingRight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //have to code in change in direction when arrow keys are pressed!!!
        xInput = UnityEngine.Input.GetAxis("Horizontal");

        facingRight = xInput > 0 ? 1 : -1;



        CheckDirection();
        Flip();
        

    }


    void Flip()
    {
        if (facingRight > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }
    void CheckDirection()
    {
        
        //float yInput = UnityEngine.Input.GetAxis("Vertical");



        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))  && xInput == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && xInput != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45*facingRight);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow)) && xInput != 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, -45*facingRight);
        }
        
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
