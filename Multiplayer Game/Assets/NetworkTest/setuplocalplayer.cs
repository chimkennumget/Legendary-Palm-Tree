using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class setuplocalplayer : NetworkBehaviour {
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
            GetComponent<CharacterMovement>().enabled = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if (isLocalPlayer)
            this.GetComponentInChildren<TextMesh>().text = pname;
        	
	}
}
