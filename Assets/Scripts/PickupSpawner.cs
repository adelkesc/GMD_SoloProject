using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    private GameObject[] spawnObjects;
    //public List<GameObject> spawned;

    private int zSpawnOffset;
    private int noSpawnOffset;
    //public GameObject collectable;

    private void Awake()
    {
        spawnObjects = Resources.LoadAll<GameObject>("SpawnPrefabs");
    }
    void Start()
    {
        //spawned = new List<GameObject>();
        SpawnObjects();
    }
    void SpawnObjects()
    {
        for(int i = 0; i < 20; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], 
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-40.0f, 250.0f)), Quaternion.identity);
            zSpawnOffset = 250;
            noSpawnOffset = 150;

            //spawned.Add(collectable);
        }
    }
    public void RecycleSpawn()
    {
        Debug.Log("Spawn More Objects.");
        zSpawnOffset += 100;
        noSpawnOffset += 100;
        Debug.Log("Spawn Object Location = " + zSpawnOffset);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)],
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(noSpawnOffset, zSpawnOffset)),
             Quaternion.identity);

            //spawned.Add(collectable);
        }
    }
    /*
    public void RemoveObject(GameObject pickup)  i don't want to lose this method
    {
        for(int i = 0; i < spawned.Count; i++)
        {
            if(pickup == spawned[i])
            {
                Debug.Log("Removed");
                spawned.Remove(spawned[i]);
            }
        }
        Debug.Log("Object Count after Remove: " + spawned.Count);
    }

    public void KillzoneDestroy(GameObject obj)
    {
        Destroy(obj);
        Debug.Log("Object Destroyed!");
    }
    */

}
