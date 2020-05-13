using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManagerMain : MonoBehaviour
{
    //private GameObject script;
    public GameObject playerPosition;
    [SerializeField]
    private float spawnOffset;
    public int checkpointLimit;

    [SerializeField]
    private GameObject checkpoint;

    private GroundMainController offsetCheck;

    // Start is called before the first frame update
    void Start()
    {
        offsetCheck = GameObject.FindObjectOfType<GroundMainController>();   
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("zOffset: " + offsetCheck.zOffset.ToString());
        if (offsetCheck.zOffset == checkpointLimit && !GameObject.FindGameObjectWithTag("Respawn"))
        {
            //SpawnCheckpoint();
            //Checkpoint spawning and the CheckpointMain class is disabled until further notice.
        }
    }

    private void SpawnCheckpoint()
    {
        spawnOffset = playerPosition.transform.position.z + 50.0f;
        Debug.Log("Instance Created!");
        Instantiate(checkpoint, new Vector3(0, 10, spawnOffset), Quaternion.identity);
    }
}
