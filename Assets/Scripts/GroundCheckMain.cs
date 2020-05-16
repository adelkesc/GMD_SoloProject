using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheckMain : MonoBehaviour
{
    private GroundMainController groundController;

    public GameObject groundObject;
    private Collider groundCollider;
    private Camera mainCam;
    Plane[] planes;

    //private IEnumerator co;

    private void Start()
    {
        mainCam = Camera.main;
        groundCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        groundController = GameObject.FindObjectOfType<GroundMainController>();
    }
    
    private void Update()
    {
        //This entire if statement is being double called!
        planes = GeometryUtility.CalculateFrustumPlanes(mainCam);
        if (GeometryUtility.TestPlanesAABB(planes, groundCollider.bounds))
        {
            Debug.Log("Ground Detected:" + groundObject.name);
            //do nothing
        }
        else
        {
            Debug.Log("Ground Not Detected:" + groundObject.name);
            
            Debug.Log("Method call to zoffset recycle ground.");
            //groundController.RecycleGround(this.gameObject);
            
            StartCoroutine(CallToGenerate());
            StopCoroutine(CallToGenerate());
        }
        
    }
    IEnumerator CallToGenerate()
    {

        Debug.Log("zoffset coroutine.");
        groundController.RecycleGround(this.gameObject);
        yield return new WaitForSeconds(1.0f);
    }
    //OnBecameInvisible is posing too much of a problem.
    //distance between ground and player
    //collision or onTriggerEnter
    /*
    private void OnBecameInvisible()
    {
        //Use something in Update to fix this method so the ground can respawn as it should
        //The dependency on camera rendering is too much trouble
        //Debug.Log("GroundCheckMain.OnBecameInvisible");
        groundController.RecycleGround(this.gameObject);
    }
        

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            onCollision = true;
        }
        else
        {
            onCollision = false;
        }
     
    }
    */
}
