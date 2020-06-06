using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public List<GameObject> spawned;
    //private GroundCheckMain groundCheck;
    [SerializeField]
    private int zSpawnOffset;
    [SerializeField]
    private int noSpawnOffset;

    private void Awake()
    {
        spawnObjects = Resources.LoadAll<GameObject>("SpawnPrefabs");
        spawned = new List<GameObject>();
        
    }
    private void OnEnable()
    {
        //groundCheck = GameObject.FindObjectOfType<GroundCheckMain>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnObjects();
    }

    private void Update()
    {

    }

    void SpawnObjects()
    {
        for(int i = 0; i < 15; i++)
        {
            //try object array = Instantiate... but create the array first.
            GameObject collectable = Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], 
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(-20.0f, 120.0f)), Quaternion.identity);
            zSpawnOffset = 120;
            noSpawnOffset = 70;

            spawned.Add(collectable);
        }
        foreach(GameObject so in spawned)
        {
            Debug.Log(so + " is in the array at: " + so.GetInstanceID());
        }
    }

    public void RecycleSpawn()
    {
        Debug.Log("Spawn More Objects.");
        zSpawnOffset += 50;
        noSpawnOffset += 50;
        Debug.Log("Spawn Object Location = " + zSpawnOffset);
        for (int i = 0; i < 10; i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)],
             new Vector3(Random.Range(-10.0f, 10.0f), 1, Random.Range(noSpawnOffset, zSpawnOffset)),
             Quaternion.identity);
        }
    }
}
