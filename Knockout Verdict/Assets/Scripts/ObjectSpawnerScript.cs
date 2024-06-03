using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour
{
    public GameObject toSpawn;

    private void OnBecameVisible()
    {
        Debug.Log("Object Instantiated");
        Instantiate(toSpawn,gameObject.transform.position, gameObject.transform.rotation);   
    }

   
}
