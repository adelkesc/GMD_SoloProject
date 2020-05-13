using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject cubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
        for(int i = 0; i < 5; i++)
        {
            Instantiate(cubePrefab, new Vector3(Random.Range(-5.0f, 5.0f), 1, Random.Range(-10.0f, 10.0f)),
            Quaternion.identity);
        }
    }
}
