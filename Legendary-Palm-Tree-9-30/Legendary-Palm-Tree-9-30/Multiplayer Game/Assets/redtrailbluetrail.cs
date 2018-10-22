using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redtrailbluetrail : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player.GetComponent<MyLobbyPlayer>().teamid == 1)
        {
            this.GetComponent<TrailRenderer>().startColor = Color.red;
            this.GetComponent<TrailRenderer>().endColor = Color.green;
        }
        else if (player.GetComponent<MyLobbyPlayer>().teamid == 2)
        {
            this.GetComponent<TrailRenderer>().startColor = Color.blue;
            this.GetComponent<TrailRenderer>().endColor = Color.yellow;
        }
    }
}
