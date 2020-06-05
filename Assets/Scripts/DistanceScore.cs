using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceScore : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI distanceText;
    private float playerStartDistance;

    private void Start()
    {
        playerStartDistance = player.position.z;
    }
    private void Update()
    {
        distanceText.text = "Distance: " + (player.position.z - playerStartDistance).ToString("0");
    }
}
