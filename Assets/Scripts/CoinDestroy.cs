using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDestroy : MonoBehaviour
{
    public GameObject coinObject;
    private Collider coinCollider;
    private Camera cam;
    Plane[] planes;

    //public string tag;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

        coinCollider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        planes = GeometryUtility.CalculateFrustumPlanes(cam);
        if(GeometryUtility.TestPlanesAABB(planes, coinCollider.bounds))
        {
            Debug.Log("Coin Object Detected! " + coinObject.name + ": " + coinObject.GetInstanceID());
        }
        else 
        {
            Debug.Log("Nothing Detected!");
            Destroy(coinObject);

        }
        */

        DeleteCoin(coinCollider);
    }

    void DeleteCoin(Collider objCol)
    {
        if(objCol.gameObject.CompareTag("Coin"))
        {
            planes = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(planes, coinCollider.bounds))
            {
                Debug.Log("Coin Object Detected! " + coinObject.name + ": " + coinObject.GetInstanceID());
            }
            else
            {
                Debug.Log("Nothing Detected!");
                Destroy(coinObject);

            }
        }
    }
}
