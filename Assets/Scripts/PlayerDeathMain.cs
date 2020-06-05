using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathMain : MonoBehaviour
{
    //private PlayerMovementMain playerScript;  //Try using this variable in place of player
    private PlayerEffects effects;

    private float deathZone;
    private float currentPosition;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        deathZone = transform.position.y - 5;
        effects = GameObject.FindObjectOfType<PlayerEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = player.transform.position.y;
        if (currentPosition <= deathZone)
        {
            FallDeath();
        }
    }

    void FallDeath()
    {
        effects.PlayerDeathEffect();
        AudioManagerMain.instance.Play("PlayerDeath");
        player.SetActive(false);
        GameOverMenu.isDead = true;
    }
}
