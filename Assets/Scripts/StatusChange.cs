using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatusChange : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    public static string effectName = "Normal";

    void Update()
    {
        statusText.text = "Status: " + effectName;
    }
}
