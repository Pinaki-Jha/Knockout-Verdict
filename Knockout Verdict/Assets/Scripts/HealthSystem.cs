using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemScript : MonoBehaviour
{
    private int health;
    private int defence;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Player") { 
            health = 100;
            defence = 0;}
        else if (gameObject.tag == "SimpleEnemy")
        {
            health = 50;
            defence = 0;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) 
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            health -= 25;
            Debug.Log("Damage Taken");
        }
    }
}
