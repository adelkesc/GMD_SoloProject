using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneMain : MonoBehaviour
{
    public GameObject killBoundary;
    public float moveSpeed;

    private PickupSpawner destroyObj;
    private bool isPaused;

    //public string[] tags = {"Cube", "Coin"}; //How to make this editable in the inspector?

    //private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        destroyObj = GameObject.FindObjectOfType<PickupSpawner>();

        StartCoroutine(PauseForPlayer());
        isPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        //The plane is rotated so it uses the Y axis to move in the Z axis.
        if(!isPaused)
        {
            killBoundary.transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
        }
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        //It works without the for and the if but destroys absolutely every object it touches.
        for(int i = 0; i < tags.Length; i++)
        {
            if(other.gameObject.tag == tags[i])
            {
                destroyObj.KillzoneDestroy(other.gameObject);
            }
        }

    }
    */

    IEnumerator PauseForPlayer()
    {
        yield return new WaitForSeconds(5f);
        isPaused = false;

    }
}
