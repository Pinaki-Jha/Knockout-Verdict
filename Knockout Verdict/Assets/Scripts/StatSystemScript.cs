using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSystemScript : MonoBehaviour
{
    

    public float maxHealth = 100f;
    public float currentHealth;
    public float attack = 0.5f;
    public float bulletSpeed =30f;
    public float defense = 0f;
    public float moveSpeed = 5.5f;
    public float jumpForce = 28f;
    public float firingRate = 0.25f;
    public bool isAlive = true;


    //This script will hold all of the stat variables and functions
    //of all of the interactable characters.
    //Stat variables will basically be variables and functions that are common for
    //all characters and/or can change based on certain conditions

    void Start()
    {
     
        currentHealth = maxHealth;    //set the current health equal to the max health
        
    }

    void Update()
    {
        Death();
    }

    private void OnTriggerEnter2D(Collider2D collision)                //when collision with a bullet
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletScript bulletScript = collision.gameObject.GetComponent<BulletScript>();

            if (bulletScript.shooter == gameObject)                        //check for friendly fire.
            {
                Debug.Log(gameObject.name + "shot self");
            }
            else
            {
                currentHealth -= bulletScript.damage;
                Debug.Log("Damage Taken by " + gameObject.name);
            }
        }
    }

    
    void Death() { if (currentHealth <= 0) {                //Check for dead player.
            name = gameObject.name;
            Debug.Log(name+ " killed");
            isAlive = false;
            Destroy(gameObject);
            
        } }
}
