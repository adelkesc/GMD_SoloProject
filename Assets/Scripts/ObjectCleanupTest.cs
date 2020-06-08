using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCleanupTest : MonoBehaviour
{
    public GameObject deadObject;
    private Collider objCollider;
    private Camera cam;
    Plane[] planes;

    public string tagName;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        objCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        CleanupObject(objCollider); //This might be called by the killzone in the future
    }

    void CleanupObject(Collider objCol)
    {
        if (objCol.gameObject.CompareTag(tagName))
        {
            planes = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(planes, objCollider.bounds))
            {
                Debug.Log("Object Detected for Cleanup! " + deadObject.name);
            }
            else
            {
                Debug.Log("Nothing Detected, Cleanup!");
                Destroy(deadObject);

            }
        }
    }
}
