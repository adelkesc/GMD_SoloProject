﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckMain : MonoBehaviour
{
    private GroundMainController groundController;
    private PickupSpawner spawner;

    public GameObject groundObject;
    private Collider groundCollider;
    private Camera mainCam;
    Plane[] planes;

    public bool groundRecycled; //used to be private

    private void Start()
    {
        mainCam = Camera.main;
        groundCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        groundController = GameObject.FindObjectOfType<GroundMainController>();
        spawner = GameObject.FindObjectOfType<PickupSpawner>();
    }
    
    private void Update()
    {
        planes = GeometryUtility.CalculateFrustumPlanes(mainCam);
        if (GeometryUtility.TestPlanesAABB(planes, groundCollider.bounds))
        {
            Debug.Log("Ground Detected:" + groundObject.name);
            groundRecycled = false;
            //do nothing
        }
        else if(!groundRecycled)
        {
            Debug.Log("Ground Not Detected:" + groundObject.name);
            Debug.Log("Method call to zoffset recycle ground.");
            groundController.RecycleGround(this.gameObject);
            groundRecycled = true;

            spawner.RecycleSpawn();
        }
        
    }
}
