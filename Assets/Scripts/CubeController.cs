using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeEffects cubeEffect;

    void Start()
    {
        cubeEffect = GameObject.FindObjectOfType<CubeEffects>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30, 0, 30) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision");
            cubeEffect.CubeCollectEffect();
        }
    }
}
