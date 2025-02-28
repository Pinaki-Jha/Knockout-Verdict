using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    public GameObject toSpawnItem;

    private void OnBecameVisible()
    {
        Debug.Log(toSpawnItem.name + " Instantiated");
        Instantiate(toSpawnItem,gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
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