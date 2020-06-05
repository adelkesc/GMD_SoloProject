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
            Instantiate(groundArray[i], new Vector3(0, 0, i * 50), Quaternion.identity);
            Debug.Log("GroundMainController - adding to zOffset in Method");
            zOffset += 50;
        }
    }

    public void RecycleGround(GameObject ground)
    {
        Debug.Log("RecycleGround - zoffset received call from GroundCheck");
        ground.transform.position = new Vector3(0, 0, zOffset);
        Debug.Log("RecycleGround - adding to zOffset in Method");
        zOffset += 50;
        Debug.Log("RecycleGround zoffset = " + zOffset);
    }
}
