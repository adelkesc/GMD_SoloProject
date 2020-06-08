using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillzoneMain : MonoBehaviour
{
    public GameObject killBoundary;
    public float moveSpeed;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(PauseForPlayer());
        //The plane is rotated so it uses the Y axis to move in the Z axis.
        killBoundary.transform.Translate(new Vector3(0, moveSpeed, 0) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("The player will die here!");
            //Trigger player death, killzone stops moving
            //player.SetActive(false);
            moveSpeed = 0;
        }
    }
    IEnumerator PauseForPlayer()
    {
        yield return new WaitForSeconds(50f);
    }
}
