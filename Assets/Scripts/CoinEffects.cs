﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEffects : MonoBehaviour
{
    public ParticleSystem coinGlitter;
    //ParticleSystem coinParticle;
    public GameObject coin;

    void Start()
    {
        //coinParticle = GetComponentInChildren<ParticleSystem>();
        Instantiate(coinGlitter, coin.transform.position, Quaternion.identity, transform.parent);
    }

    public void OnCoinCollect()
    {
        //coinParticle.Play(); disabled for now
        AudioManagerMain.instance.Play("CoinCollected");
    }
}
