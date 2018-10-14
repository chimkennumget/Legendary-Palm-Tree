using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class GUITeam : NetworkBehaviour {
    GUITeam gtm;
    team myid;
    GameObject player;
    bool clicked=false;
    int idnumber;

    // Use this for initialization
    public void Start()
    {
        gtm = GetComponent<GUITeam>();
        NetworkInstanceId playerId =  this.netId;//get id of this gameobject
        player = NetworkServer.FindLocalObject(playerId);//find gameobject via playerid
        player = ClientScene.FindLocalObject(playerId);
        Debug.Log(player);
        myid = player.GetComponent<team>();
        Debug.Log(myid.TeamID);
        idnumber = myid.TeamID;
        myid.TeamID = idnumber;
        
    }

   
    
    public Texture btnTexture;
    [Command]
    void Cmdupdateid1(int idnum)
    {
        idnumber = idnum;
        if (idnumber != 1)
        {
            Debug.Log(idnumber);
            idnum = 1;
        }
        myid.TeamID = idnum;
    }
    [ClientRpc]
    void Rpcupdateid1(int idnum)
    {
        //idnumber = myid.TeamID;
        //myid.TeamID = idnum;
        NetworkInstanceId playerId = this.netId;//get id of this gameobject
        player = NetworkServer.FindLocalObject(playerId);//find gameobject via playerid
        player = ClientScene.FindLocalObject(playerId);
        Debug.Log(player);
        myid = player.GetComponent<team>();
        Debug.Log(myid.TeamID);
        idnumber = 1;
        myid.TeamID = idnumber;
    }
    void Cmdupdateid2(int idnum)
    {
        idnumber = idnum;
        if (idnumber != 2)
        {
            Debug.Log(idnumber);
            idnum = 2;
        }
        myid.TeamID = idnum;
    }
    [ClientRpc]
    void Rpcupdateid2(int idnum)
    {
        //idnumber = myid.TeamID;
        //myid.TeamID = idnum;
        NetworkInstanceId playerId = this.netId;//get id of this gameobject
        player = NetworkServer.FindLocalObject(playerId);//find gameobject via playerid
        player = ClientScene.FindLocalObject(playerId);
        Debug.Log(player);
        myid = player.GetComponent<team>();
        Debug.Log(myid.TeamID);
        idnumber = 1;
        myid.TeamID = idnumber;
    }

    void OnGUI()
    {
        if (!btnTexture)
        {
            Debug.LogError("Please assign a texture on the inspector");
            return;
        }

        if (GUI.Button(new Rect(10, 10, 50, 50), "Team 1") && !clicked)
        {
            myid.TeamID = 1;
            idnumber = myid.TeamID;
            Debug.Log(myid.TeamID);
            clicked = true;
            if (!isServer)
            {
                Cmdupdateid1(idnumber);
            }
            else {
                Rpcupdateid1(idnumber);
            }
        }

        if (GUI.Button(new Rect(10, 70, 50, 30), "Team 2"))
        {
            myid.TeamID = 2;
            idnumber = myid.TeamID;
            Debug.Log(myid.TeamID);
            clicked = true;
            if (!isServer)
            {
                Cmdupdateid2(idnumber);
            }
            else
            {
                Rpcupdateid2(idnumber);
            }

        }
        if (clicked)
        {
            gtm.enabled = false;
        }
    }
}
