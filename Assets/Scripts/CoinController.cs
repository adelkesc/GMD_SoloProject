using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject coin;
    public CoinEffects coinFX;
    //ParticleSystem coinParticle;

    private void Awake()
    {
        coinFX = GameObject.FindObjectOfType<CoinEffects>();
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
            coinFX.OnCoinCollect();
            CoinScore.coinScore += 1;
            Debug.Log("coinScoring!");
            //coin.SetActive(false);
        }
    }
}
