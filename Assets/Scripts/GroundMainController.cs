using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMainController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] groundArray;
    public int zOffset;
    //public Transform world;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGround();
    }
    public void GenerateGround()
    {
        for (int i = 0; i < groundArray.Length; i++)
        {
            Instantiate(groundArray[i], new Vector3(0, 0, i * 100), Quaternion.identity);
            Debug.Log("GroundMainController - adding to zOffset in Method");
            zOffset += 100;
        }
    }
    public void RecycleGround(GameObject ground)
    {
        ground.transform.position = new Vector3(0, 0, zOffset);
        zOffset += 100;
        Debug.Log("RecycleGround zoffset = " + zOffset);
    }
}
