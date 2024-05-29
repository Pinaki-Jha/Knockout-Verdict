using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GunDirectionScript : MonoBehaviour
{
    private bool isRotated = false;
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
        float xInput = UnityEngine.Input.GetAxis("Horizontal");
        float yInput = UnityEngine.Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.W) && Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.W) && Mathf.Abs(xInput) > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.S) && Mathf.Abs(xInput) < 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else if (Input.GetKey(KeyCode.S) && Mathf.Abs(xInput) > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

}
