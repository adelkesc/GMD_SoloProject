using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositions : MonoBehaviour
{
    private List<Transform> transforms;
    private GroundMainController offsetCheck;

    // Start is called before the first frame update
    void Start()
    {
        offsetCheck = GameObject.FindObjectOfType<GroundMainController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    public void ResetAll()
    {
        foreach(Transform child in transform)
        {
            child.position = new Vector3(child.position.x, child.position.y, child.position.z - 100);
        }
        //offsetCheck.zOffset = -100;
        //offsetCheck.zOffset = 150;
    }
    */
}
