using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // Jis gun object se fire horaha hoga uski property hogi firing rate/speed uss se nikaal ke speed daal denge
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
