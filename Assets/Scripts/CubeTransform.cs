using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTransform : MonoBehaviour
{
    public GameObject player; //make this private later

    public Mesh normalSphere;
    public Mesh cubed;

    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        normalSphere = player.GetComponent<MeshFilter>().mesh;

        sphereCollider = player.GetComponent<SphereCollider>();
        boxCollider = player.GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TransformPlayer();
        }
    }
    private void TransformPlayer()
    {
        sphereCollider.enabled = false;
        boxCollider.enabled = true;

        player.GetComponent<MeshFilter>().mesh = cubed;

        StartCoroutine(PauseForStatus());
    }
    IEnumerator PauseForStatus()
    {
        yield return new WaitForSeconds(2f);

        //Returns the mesh to a normal sphere.
        player.GetComponent<MeshFilter>().mesh = normalSphere;

        sphereCollider.enabled = true;
        boxCollider.enabled = false;
    }
}
