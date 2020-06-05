using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    private GroundManager groundManager;

    public GameObject groundPlaneObject;
    private Collider groundPlane;
    private Camera mainCam;
    Plane[] planesCam;

    private bool groundRecycled;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        groundPlane = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        groundManager = GameObject.FindObjectOfType<GroundManager>();
    }

    private void Update()
    {
        planesCam = GeometryUtility.CalculateFrustumPlanes(mainCam);
        if (GeometryUtility.TestPlanesAABB(planesCam, groundPlane.bounds))
        {
            Debug.Log("Ground Detected:" + groundPlaneObject.name);
            groundRecycled = false;
            //do nothing
        }
        else if (!groundRecycled)
        {
            Debug.Log("Ground Not Detected:" + groundPlaneObject.name);
            Debug.Log("Method call to zoffset recycle ground.");
            groundManager.RecycleGround(this.gameObject);
            groundRecycled = true;
        }
    }

}
