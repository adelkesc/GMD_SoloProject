using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockKnockback : MonoBehaviour //IInteractable
{
    public float knockForce;
    private GameObject player;
    private Rigidbody playerRB;

    private BlockCubeEffects blockEffects;

    private void Awake()
    {
        blockEffects = GameObject.FindObjectOfType<BlockCubeEffects>();
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            blockEffects.onContact();
            playerRB.AddForce(playerRB.velocity * -knockForce, ForceMode.Impulse);
        }
    }
}
