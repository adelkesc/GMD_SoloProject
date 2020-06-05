using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    public ParticleSystem explodeParticle;
    public GameObject player;

    public void PlayerDeathEffect()
    {
        Instantiate(explodeParticle, player.transform.position, Quaternion.identity);
    }
}
