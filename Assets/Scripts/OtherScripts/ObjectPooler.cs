using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public GameObject[] pool;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        pool = Resources.LoadAll<GameObject>("SpawnPrefabs");
    }

    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }

}
