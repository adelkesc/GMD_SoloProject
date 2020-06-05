using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public delegate void PlayerEvent();
    public static event PlayerEvent StatusUpdate;
    /*
    public static void OnPlayerChange()
    {
        if (StatusUpdate != null)
        {
            StatusUpdate();
        }
    }
    */
}
