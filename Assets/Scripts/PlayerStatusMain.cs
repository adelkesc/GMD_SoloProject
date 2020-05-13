using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusMain : MonoBehaviour
{
    //public PlayerMovementMain playerStatus;
    //public float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        //Attempting to get the speed of the rigidbody without making the variable
        //public in PlayerMovementMain
        //currentSpeed = playerStatus.GetComponent<Rigidbody>().velocity.magnitude;
    }
}
