using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportControllerBoost : MonoBehaviour
{
    // Maybe try to find these game objects in Start as private variables in Main
    public GameObject player; 
    public GameObject respawnPoint;

    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = respawnPoint.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPosition;
        }
    }
}
