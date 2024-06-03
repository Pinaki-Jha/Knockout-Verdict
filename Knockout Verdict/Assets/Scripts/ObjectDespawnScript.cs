using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDespawnScript : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("object despawned.");
    }

}
