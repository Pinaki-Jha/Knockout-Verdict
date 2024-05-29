using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject Bullet;
    public Transform GunNozzle;
    public float FiringRate;  

    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        FiringRate = 0.25f; //Change according to the gun being used later on
        counter = FiringRate;
    }

    // Update is called once per frame
    void Update()
    {

        //when coding movement to flip the player use rotation of 180 degrees in y instead of flip command vector usage!!!
        //the latter does not flip the gun nozzle with it, which will lead to many many problems!!!


        //checks for shooting!
        if (Input.GetKey(KeyCode.W)) 
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (counter >= FiringRate)
        {
            Instantiate(Bullet, GunNozzle.position, GunNozzle.rotation);
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }
        
    }
}
