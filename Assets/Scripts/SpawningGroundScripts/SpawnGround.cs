using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    private GroundManager groundManager;

    // Start is called before the first frame update
    void Start()
    {
    
    }
    private void OnEnable()
    {
        groundManager = GameObject.FindObjectOfType<GroundManager>();
    }

    private void OnBecameInvisible()
    {
        //Use something in Update to fix this method so the ground can respawn as it should
        //The dependency on camera rendering is too much trouble
        Debug.Log("GroundManager.OnBecameInvisible");
        groundManager.RecycleGround(this.gameObject);
    }
}
