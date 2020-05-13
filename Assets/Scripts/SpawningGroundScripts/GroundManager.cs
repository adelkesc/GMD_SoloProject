using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundArray;
    public int zOffset;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGround();
    }

    public void GenerateGround()
    {
        for (int i = 0; i < groundArray.Length; i++)
        {
            Instantiate(groundArray[i], new Vector3(0, 0, i * 50), Quaternion.identity);
            zOffset += 50;
        }
    }

    public void RecycleGround(GameObject ground)
    {
        ground.transform.position = new Vector3(0, 0, zOffset);
        Debug.Log("Increment");
        zOffset += 50;
    }
}
