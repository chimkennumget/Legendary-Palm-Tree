using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teamlight : MonoBehaviour {

    public GameObject player;
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<MyLobbyPlayer>().teamid == 1)
        {
            this.GetComponent<Light>().color = Color.red;
        }
        else if (player.GetComponent<MyLobbyPlayer>().teamid == 2)
        {
            this.GetComponent<Light>().color = Color.blue;
        }
    }
}
