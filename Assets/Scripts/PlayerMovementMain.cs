using UnityEngine;

public class PlayerMovementMain : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float physicsSpeed;

    private float moveHorizontal;
    private float moveVertical;
    private bool isButtonDown = false;
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
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        isButtonDown = Input.GetButtonDown("Jump");
    }

    private void FixedUpdate()
    {
        physicsSpeed = rb.velocity.magnitude;
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);

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
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
