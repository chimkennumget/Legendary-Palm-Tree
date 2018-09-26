using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        //is this actually my player?
        if(isLocalPlayer == false)
        {
            //object belongs to another player.
            return;
        }
        Debug.Log("PlayerObject::Start -- Spawning my own personal unit.");
        //instantiate() only creates object on the Local Computer.
        //Even if it has a Network Identity it is still will Not exist on
        //the network (and therfore not on any other client) UNLESS
        //NetworkServer.Spawn() is called on this object.
        Instantiate(PlayerUnitPrefab);//give me something to see that I use
	}
    public GameObject PlayerUnitPrefab;//our physical player
	// Update is called once per frame
	void Update () {
		
	}
}
