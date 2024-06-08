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


    /*IEnumerator SpawnMedKits()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnMedKit();
        }
    }

    void SpawnMedKit()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(medKitPrefab, spawnPoint.position, spawnPoint.rotation);
    }*/

}