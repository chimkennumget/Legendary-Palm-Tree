﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class setuplocalplayer : NetworkBehaviour {
    public Camera fpscamera;
    [SyncVar]
    public string pname = "player";

    void OnGUI()
    {
        if (isLocalPlayer)
        {
            pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), pname);
            
            if(GUI.Button(new Rect(130,Screen.height - 40, 80, 30), "Change"))
            {
                
                CmdChangeName(pname);
            }
        }
    }

    [Command]
    public void CmdChangeName(string newName)
    {
        pname = newName;
        
    }
    // Use this for initialization
    void Start () {
        if (isLocalPlayer)
        {
            
            
            fpscamera = Camera.main;
            GetComponent<CharacterMovement>().enabled = true;
            //Camera.main.transform.position = this.transform.position -
            //    this.transform.forward * 4 + this.transform.up * 3;
           // Camera.main.transform.LookAt(this.transform.position);
           // Camera.main.transform.parent = this.transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if (isLocalPlayer)
            this.GetComponentInChildren<TextMesh>().text = pname;
        	
	}
}
