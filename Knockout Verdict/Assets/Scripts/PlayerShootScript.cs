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
    private bool isShooting = false;

    private Coroutine shootingCoroutine;
    
    void Start()
    {
        FiringRate = playerStats.firingRate; 
    }

    
    void Update()
    {


        //checks for shooting!
        if (Input.GetKeyDown(KeyCode.W) && !isShooting) 
        {
            isShooting=true;
            shootingCoroutine = StartCoroutine(Shoot());
        }

        if (Input.GetKeyUp(KeyCode.W) && isShooting) 
        {
            isShooting=false;
            StopCoroutine(shootingCoroutine);
        
        }

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            GameObject shotBullet = Instantiate(bullet, gunNozzle.position, gunNozzle.rotation);
            BulletScript bulletScript = shotBullet.GetComponent<BulletScript>();
            bulletScript.shooter = player; // Set the shooter reference for the bullet.
            yield return new WaitForSeconds(FiringRate);
            
        }
        
    }
}
