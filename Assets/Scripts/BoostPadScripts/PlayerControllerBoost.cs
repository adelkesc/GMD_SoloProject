using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBoost : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float actualSpeed;

    private bool isGrounded = true;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //On spacebar jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //jump
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("NewHorizontal");
        float moveVertical = Input.GetAxis("NewVertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        actualSpeed = rb.velocity.magnitude;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
