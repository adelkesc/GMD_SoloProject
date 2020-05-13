using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathMain : MonoBehaviour
{
    private PlayerMovementMain playerScript;  //Try using this variable in place of player
    private float deathZone;
    private float currentPosition;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        deathZone = transform.position.y - 5;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = player.transform.position.y;
        if (currentPosition <= deathZone)
        {
            player.SetActive(false);
            GameOverMenu.isDead = true;
        }
    }
}
