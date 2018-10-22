using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class MyLobbyPlayer : NetworkLobbyPlayer
{
    // Team
    [SyncVar]
    public int teamid;

    // Buttons
    public Button redTeam;
    public Button blueTeam;
    

    public override void OnStartClient()
    {
        base.OnStartClient();
        
        // Initially hide buttons for clients
        redTeam.gameObject.SetActive(false);
        blueTeam.gameObject.SetActive(false);
    }
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();

        // When client is set as local, enable buttons
        redTeam.gameObject.SetActive(true);
        blueTeam.gameObject.SetActive(true);

        // Add listeners
        redTeam.onClick.RemoveAllListeners();
        redTeam.onClick.AddListener(OnClickRed);

        blueTeam.onClick.RemoveAllListeners();
        blueTeam.onClick.AddListener(OnClickBlue);
    }

    public void OnClickRed()
    {
        // Clicked red team (team nr 0)
        CmdSelectTeam(1);
        Debug.Log("clicked team 1");
        redTeam.gameObject.SetActive(false);
        blueTeam.gameObject.SetActive(false);
    }

    public void OnClickBlue()
    {
        // Clicked blueteam (team nr 1)
        CmdSelectTeam(2);
        Debug.Log("clicked team 2");
        redTeam.gameObject.SetActive(false);
        blueTeam.gameObject.SetActive(false);
    }

    [Command]
    public void CmdSelectTeam(int teamIndex)
    {
        // Set team of player on the server.
        teamid = teamIndex;
    }

}