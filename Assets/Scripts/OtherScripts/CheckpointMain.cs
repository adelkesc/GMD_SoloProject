using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointMain : MonoBehaviour
{
    public GameObject player;
    private Vector3 respawnPosition;
    //public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawnPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnPosition;
            //isTriggered = true;
        }
    }
}
