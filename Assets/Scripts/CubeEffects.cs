using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEffects : MonoBehaviour
{
    public ParticleSystem collectParticle;
    public GameObject cube;

    public void CubeCollectEffect()
    {
        //Instantiate(collectParticle, cube.transform.position, Quaternion.Euler(90, 0, 0));
    }
}
