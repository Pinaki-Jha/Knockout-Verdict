using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public StatSystemScript playerStats;
    public Transform gunNozzle;

    private float FiringRate = 0.25f;  
    private float counter;
    
    void Start()
    {
        FiringRate = playerStats.firingRate; 
        counter = FiringRate;
    }

    
    void Update()
    {


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
            Instantiate(bullet, gunNozzle.position, gunNozzle.rotation);
            BulletScript bulletScript = bullet.GetComponent<BulletScript>();
            bulletScript.shooter = player; // Set the shooter reference for the bullet.
            counter = 0;
        }
        else
        {
            counter += Time.deltaTime;
        }
        
    }
}
