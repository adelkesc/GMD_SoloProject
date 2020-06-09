using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject coin;
    public CoinEffects coinFX;
    public GameObject collectObject;

    private void Awake()
    {
        coinFX = GameObject.FindObjectOfType<CoinEffects>();
    }
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
            Destroy(collectObject);
        }
    }
}
