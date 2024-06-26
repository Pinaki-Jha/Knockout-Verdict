using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject player;
    public StatSystemScript playerStats;
    public Transform gunNozzle;

    private float FiringDelay = 0.25f;
    private bool isShooting = false;

    AudioManagerScript audioManager;

    private Coroutine shootingCoroutine;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManagerScript>();
    }

    void Start()
    {
        FiringDelay = playerStats.firingDelay; 
    }

    
    void Update()
    {


        //checks for shooting!
        if (Input.GetKeyDown(KeyCode.W) && !isShooting && Time.timeScale==1) 
        {
            isShooting=true;
            shootingCoroutine = StartCoroutine(Shoot());

            audioManager.PlaySFX(audioManager.GunShot);
        }

        if (Input.GetKeyUp(KeyCode.W) && isShooting && Time.timeScale==1) 
        {
            isShooting=false;
            StopCoroutine(shootingCoroutine);
        
        }

    }

    IEnumerator Shoot()
    {
        while (true)
        {
            
            {
                GameObject shotBullet = Instantiate(bullet, gunNozzle.position, gunNozzle.rotation);
                BulletScript bulletScript = shotBullet.GetComponent<BulletScript>();
                bulletScript.shooter = player; // Set the shooter reference for the bullet.
                yield return new WaitForSeconds(FiringDelay);
            }
            
        }
        
    }
}
