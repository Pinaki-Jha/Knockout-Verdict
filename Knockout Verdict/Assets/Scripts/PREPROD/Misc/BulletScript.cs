using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject shooter;  //Who shot the bullet
    public float speed;        //speed of the bullet
    public float damage;
    void Start()
    {
        if (shooter)
        {
            StatSystemScript shooterStats = shooter.GetComponent<StatSystemScript>();
            speed = shooterStats.bulletSpeed;
            damage = shooterStats.attack;

        }
        /*Testing
        if (shooter.CompareTag("Player"))
        {
            Debug.Log("Bullet shot by player");
        }
        */
        Debug.Log("bullet shot by" + shooter.name);
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*Testing
         if(collision.gameObject == shooter)
        {
            //Debug.Log("Shot self");
        }
        */

        Destroy(gameObject);
    }
}
