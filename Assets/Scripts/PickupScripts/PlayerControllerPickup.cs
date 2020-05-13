using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPickup : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    
    private float moveHorizontal;
    private float moveVertical;
    private bool isButtonDown = false;
    private bool isGrounded = true;

    private Rigidbody rb;
    //public GameObject player;
    //public GameObject cube;
    /*I don't need to reference the player for the mesh swap because the reference is coming from the Mesh 
     * variable in Unity.  GetComponent works on the game object that this script is attached to 
     * so I don't need a reference in this case.
    */

    public Mesh normalSphere;
    public Mesh cubed;

    public SphereCollider sphereCollider;
    public BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        normalSphere = GetComponent<MeshFilter>().mesh;
        //Gets the mesh referenced in Unity and stores it in a variable.

        sphereCollider = GetComponent<SphereCollider>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        isButtonDown = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

        // jump
        if (isButtonDown && isGrounded)
        {
            rb.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode.Impulse);
            isGrounded = false;
            isButtonDown = false;

            //May want to extend function so if jump is held then the character jumps higher or longer
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            //other.gameObject.SetActive(false);
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
        else if (other.gameObject.CompareTag("Cube"))
        {
            other.gameObject.SetActive(false);
            TransformPlayer();
        }
        else if (other.gameObject.CompareTag("FlyWheel"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void TransformPlayer()
    {
        //have them in start and use set active?
        //GetComponent<SphereCollider>().enabled = false;
        //GetComponent<BoxCollider>().enabled = true;
        //Swaps the current mesh with the mesh stored in the cubed variable.
        sphereCollider.enabled = false;
        boxCollider.enabled = true;

        GetComponent<MeshFilter>().mesh = cubed;


        StartCoroutine(PauseForStatus());
    }

    IEnumerator PauseForStatus()
    {
        yield return new WaitForSeconds(10f);

        //Returns the mesh to a normal sphere.
        GetComponent<MeshFilter>().mesh = normalSphere;


        //GetComponent<BoxCollider>().enabled = false;
        //GetComponent<SphereCollider>().enabled = true;
        sphereCollider.enabled = true;
        boxCollider.enabled = false;
    }
}
