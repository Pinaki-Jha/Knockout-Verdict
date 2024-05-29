using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GunDirectionScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //have to code in change in direction when arrow keys are pressed!!!
        
        CheckDirection();
        
        

    }

    void CheckDirection()
    {

        //float yInput = UnityEngine.Input.GetAxis("Vertical");

        float xInput = UnityEngine.Input.GetAxis("Horizontal");
        int facingRight = xInput > 0 ? -1 : 1;


        if (Input.GetKey(KeyCode.UpArrow)  && xInput == 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90);
            Debug.Log("aiming up");
        }
        else if (Input.GetKey(KeyCode.UpArrow) && xInput != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 45);
            Debug.Log("aiming diagonal up");
        }
        else if (Input.GetKey(KeyCode.DownArrow) && xInput != 0) 
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -45);
            Debug.Log("aiming diagonal down");
        }
        
        else
        {
            //float toRotate = xInput>0?0:180;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Debug.Log("aiming straight");
        }

    }

}
