using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinScore : MonoBehaviour
{
    public TextMeshProUGUI collectedText;
    public static int coinScore;

    // Update is called once per frame
    void Update()
    {
        collectedText.text = "Coins: " + coinScore.ToString();
        /*set an alert in the coin's script to detect when the coin has 
         * been collected so the score will be added here.
         */
    }
}
