using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCubeEffects : MonoBehaviour
{
    public ParticleSystem hitParticle;
    public GameObject blockCube;

    public void onContact()
    {
        Instantiate(hitParticle, blockCube.transform.position, Quaternion.identity);
        AudioManagerMain.instance.Play("PatrolHit");
    }
}
