using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject coin;
    ParticleSystem coinParticle;

    // Start is called before the first frame update
    void Start()
    {
        coinParticle = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 90) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //particle system
            coinParticle.Play();
            CoinScore.coinScore += 1;
            Debug.Log("coinScoring!");
            //coin.SetActive(false);
        }

    }
}
