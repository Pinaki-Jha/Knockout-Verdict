using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawnScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
    }
}
