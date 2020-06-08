using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeEffects cubeEffect;
    private PickupSpawner spawner;
    public GameObject cube;

    void Start()
    {
        cubeEffect = GameObject.FindObjectOfType<CubeEffects>();
        spawner = GameObject.FindObjectOfType<PickupSpawner>();
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
            cubeEffect.CubeCollectEffect();
            CoinScore.coinScore -= 1;
            //Debug.Log("Call To Remove");
            //spawner.RemoveObject(cube);
            Destroy(cube);
        }
    }
}
