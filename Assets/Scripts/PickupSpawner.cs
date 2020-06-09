using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public List<GameObject> spawned;

    [SerializeField]
    private int zSpawnOffset;
    [SerializeField]
    private int noSpawnOffset;
    public GameObject collectable;

    /*
    public GameObject deadObject;
    private Collider objCollider;
    private Camera cam;
    Plane[] planes;
    */

    private void Awake()
    {
        spawnObjects = Resources.LoadAll<GameObject>("SpawnPrefabs");
        spawned = new List<GameObject>();  //put this in start
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();

        //cam = Camera.main;
        //objCollider = GetComponent<Collider>();
    }

    /*
    private void Update()
    {
        Cleanup(objCollider);
    }
    private void Cleanup(Collider objCol)
    {
        for (int i = 0; i < spawned.Count; i++)
        {
            if(objCol.gameObject == spawned[i].gameObject)
            {
                Debug.Log(objCol.gameObject.name);
            }
        }
    }
    */

    void SpawnObjects()
    {
        for(int i = 0; i < 20; i++)
        {
            //try object array = Instantiate... but create the array first. +20  -20 to 120 (120, 70)
            collectable = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], 
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-40.0f, 250.0f)), Quaternion.identity);
            zSpawnOffset = 250;
            noSpawnOffset = 150;

            //spawned.Add(collectable);
            //Debug.Log("Object Count: " + spawned.Count);
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
            collectable = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)],
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(noSpawnOffset, zSpawnOffset)),
             Quaternion.identity);

            //spawned.Add(collectable);
        }
    }

    public void RemoveObject(GameObject pickup)
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

}
