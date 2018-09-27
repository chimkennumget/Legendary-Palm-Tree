using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerConnectionObject : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        playerCamera.enabled = false;
        //is this actually my player?
        if(isLocalPlayer == false)
        {
            //object belongs to another player.
            return;
        }
        Debug.Log("PlayerConnectionObject::Start -- Spawning my own personal unit.");
        //instantiate() only creates object on the Local Computer.
        //Even if it has a Network Identity it is still will Not exist on
        //the network (and therfore not on any other client) UNLESS
        //NetworkServer.Spawn() is called on this object.
        //Instantiate(PlayerUnitPrefab);//give me something to see that I use
        //Commands server to spawn our unit
        CmdSpawnMyUnit();

	}
    public GameObject PlayerUnitPrefab;//our physical player
    public Camera playerCamera;

    //SyncVars are variables where if their value changes on the sERVER, then all clients
    //are automatically informed of the new value.
    [SyncVar(hook="OnPlayerNameChanged") ]
    public string PlayerName = "Anonymous";


	// Update is called once per frame
	void Update () {
        //Remember update runs on everyone's computer , whether or not they own this particular platyer object.
        if (isLocalPlayer == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            CmdSpawnMyUnit();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            string n = "Dude" + Random.Range(1, 100);
            Debug.Log("sending the server a msg to change the players name to " + n);
            CmdChangePlayerName(n);
        }






    }
    //Warning: if you use a hook on a SyncVar, then our local value does not get automatically udated
    void OnPlayerNameChanged(string newName)
    {
        Debug.Log("OnPlayerNameChanged: OldName:  " + PlayerName+ "NewName: " + newName);
        PlayerName = newName;
        gameObject.name = "PLayerConnectionObject [" + newName + "]";
    }
    //GameObject myPlayerUnit;
    public GameObject go;
    /////////COMMANDS
    //commands are special functions that Only get executed ont he server.
    [Command]//executes on the server
    void CmdSpawnMyUnit()//must start with Cmd to be a Command function
    {
        if(go)//dont want copies of me causing problems
        {
            Destroy(go);
            //DestroyImmediate(Camera.main.gameObject);
            
        }
        //We are guarnateed to be on the server right now.
        go = Instantiate(PlayerUnitPrefab);//give me something to see that I use
        if (playerCamera.enabled)
        {
            return;
            Debug.Log("shouldn't be summoning");
        }
        else
        {
            playerCamera.enabled = true;
            Instantiate(playerCamera);
            playerCamera = Camera.main;
        }
        //Camera.main.enabled = true;
        //go.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
        //connectiontoclient points to person that has this player object

        // myPlayerUnit = go;



        //now that the object exists on the server, propagate it to all the clients
        //also wire up the NetworkIdentity
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
        
    }

    [Command]
    void CmdChangePlayerName(string n)
    {
        Debug.Log("CmdChangePlayerName: " + n);
        PlayerName = n;
        //tell all the clients what this players name now is
        //RpcChangePlayerName(PlayerName);
    }
    ////////////////////RPC
    // RPC's are special functions that ONLY get executed on the clients

   /* [ClientRpc]
    void RpcChangePlayerName(string n)
    {
        Debug.Log("RpcChangePlayerName: we were asked to change the player name on a particualr PlayerConnectionObject: " + n);
        PlayerName = n;

       
    }
    */

    //[Command]
    //void CmdMoveUnitUp()
    //{
    //    if(myPlayerUnit == null)
    //    {
    //        return;
    //    }

    //    myPlayerUnit.transform.Translate(0, 1, 0);
    //}
}
