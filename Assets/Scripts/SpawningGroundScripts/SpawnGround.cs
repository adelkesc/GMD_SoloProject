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
            //do nothing
        }
        else
        {
            Debug.Log("Ground Not Detected:" + groundPlaneObject.name);

            Debug.Log("Method call to zoffset recycle ground.");
            //groundController.RecycleGround(this.gameObject);

            StartCoroutine(CallToGenerate());
            StopCoroutine(CallToGenerate());
        }
    }
    IEnumerator CallToGenerate()
    {

        Debug.Log("zoffset coroutine.");
        groundManager.RecycleGround(this.gameObject);
        yield return new WaitForSeconds(1.0f);
    }
    /*
        private void OnBecameInvisible()
        {
            //Use something in Update to fix this method so the ground can respawn as it should
            //The dependency on camera rendering is too much trouble
            Debug.Log("GroundManager.OnBecameInvisible");
            groundManager.RecycleGround(this.gameObject);
        }
    */

}
