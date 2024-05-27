using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GunDirectionScript : MonoBehaviour
{
    // Start is called before the first frame update
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
        if (Input.GetKey(KeyCode.UpArrow) && Input.GetAxis("Horizontal") == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetAxis("Horizontal") != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 45);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetAxis("Horizontal") != 0) 
        {
            transform.rotation = Quaternion.Euler(0, 0, -45);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

   
}
