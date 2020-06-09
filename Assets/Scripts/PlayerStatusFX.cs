using System.Collections;
using UnityEngine;

public class PlayerStatusFX : MonoBehaviour
{
    public Mesh normalSphere;
    public Mesh cubed;

    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        normalSphere = GetComponent<MeshFilter>().mesh;
        sphereCollider = GetComponent<SphereCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            TransformPlayer();
        }
    }
    private void TransformPlayer()
    {
        StatusChange.effectName = "Cubed";
        sphereCollider.enabled = false;
        boxCollider.enabled = true;

        GetComponent<MeshFilter>().mesh = cubed;
        StartCoroutine(PauseForStatus());
    }
    IEnumerator PauseForStatus()
    {
        yield return new WaitForSeconds(10f);
        StatusChange.effectName = "Normal";

        //Returns the mesh to a normal sphere.
        GetComponent<MeshFilter>().mesh = normalSphere;
        sphereCollider.enabled = true;
        boxCollider.enabled = false;
    }
}
