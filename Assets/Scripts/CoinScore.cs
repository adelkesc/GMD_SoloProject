﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public TextMeshProUGUI collectedText;
    public static int coinScore;

    private void Start()
    {
        coinScore = 0;
    }
    // Update is called once per frame
    void Update()
    {
        collectedText.text = "Coins: " + coinScore.ToString();
    }
}
