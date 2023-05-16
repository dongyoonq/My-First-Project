using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    void Awake()
    {
        if(player != null)
            player.name = "Player";
    }
}
