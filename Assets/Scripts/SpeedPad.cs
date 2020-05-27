using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPad : MonoBehaviour
{
    public float speedBoost;
    private PlayerMovementMain playerScript;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //find the game object and give access to the script
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovementMain>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Prefabs can't reference scene objects.  I need a workaround.

            speedBoost = playerScript.physicsSpeed * 2;
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, speedBoost), ForceMode.Impulse);

            Debug.Log("Boost:" + speedBoost);
        }
    }
}
