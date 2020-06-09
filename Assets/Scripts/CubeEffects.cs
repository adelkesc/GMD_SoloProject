using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEffects : MonoBehaviour
{
    public ParticleSystem collectParticle;

    public void CubeCollectEffect(GameObject obj)
    {
        Instantiate(collectParticle, obj.transform.position, Quaternion.Euler(90, 0, 0));
        AudioManagerMain.instance.Play("CubeCollected");
    }
}
