using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking.Types;
using UnityEngine.Networking.Match;

public class MyLobbyPlayer : NetworkLobbyPlayer
{
    public GameObject puiholder;
    // Team
    [SyncVar]
    public int teamid;
    
    public bool stillchoosing=true;
    [SyncVar]
    public bool t1sp1b;
    [SyncVar]
    public bool t1sp2b;
    [SyncVar]
    public bool t1sp3b;
    [SyncVar]
    public bool t1sp4b;
    bool[] t1bools = new bool[4];
    [SyncVar]
    public bool t2sp1b;
    [SyncVar]
    public bool t2sp2b;
    [SyncVar]
    public bool t2sp3b;
    [SyncVar]
    public bool t2sp4b;
    bool[] t2bools = new bool[4];
    public GameObject t1sp1;
    public GameObject t1sp2;
    public GameObject t1sp3;
    public GameObject t1sp4;
    public GameObject t1sp5;
    public GameObject t1sp6;
    public GameObject t1sp7;
    public GameObject t1sp8;
    GameObject[] t1spawns = new GameObject[8];
    public GameObject t2sp1;
    public GameObject t2sp2;
    public GameObject t2sp3;
    public GameObject t2sp4;
    public GameObject t2sp5;
    public GameObject t2sp6;
    public GameObject t2sp7;
    public GameObject t2sp8;
    GameObject[] t2spawns = new GameObject[8];
    public SkinnedMeshRenderer sailor;
    public SkinnedMeshRenderer black;
    public Button redTeam;
    public Button blueTeam;
    //buttons
    Button[] buttons = new Button[2];

    private int y = 0;
    private void Start()
    {
        //add spawns for team 1 to t1 list
        t1spawns[0] = t1sp1;
        t1spawns[1] = t1sp2;
        t1spawns[2] = t1sp3;
        t1spawns[3] = t1sp4;
        t1spawns[4] = t1sp5;
        t1spawns[5] = t1sp6;
        t1spawns[6] = t1sp7;
        t1spawns[7] = t1sp8;

        //add spawns for team 2 to t2 list
        t2spawns[0] = t2sp1;
        t2spawns[1] = t2sp2;
        t2spawns[2] = t2sp3;
        t2spawns[3] = t2sp4;
        t2spawns[4] = t2sp5;
        t2spawns[5] = t2sp6;
        t2spawns[6] = t2sp7;
        t2spawns[7] = t2sp8;


    }
    void restartinggame()
    {
        
        {
            GetComponent<MyLobbyPlayer>().teamid = 0;
            GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(false);
            GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(false);


            GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(true);
            GetComponent<MyLobbyPlayer>().blueTeam.onClick.RemoveAllListeners();
            GetComponent<MyLobbyPlayer>().redTeam.gameObject.SetActive(true);
            GetComponent<MyLobbyPlayer>().redTeam.onClick.RemoveAllListeners();





            // Add listeners
            //redTeam.onClick.RemoveAllListeners();
            GetComponent<MyLobbyPlayer>().redTeam.onClick.AddListener(GetComponent<MyLobbyPlayer>().OnClickT1);

            // blueTeam.onClick.RemoveAllListeners();
            GetComponent<MyLobbyPlayer>().blueTeam.onClick.AddListener(GetComponent<MyLobbyPlayer>().OnClickT2);
        }
    }
    public override void OnStartClient()
    {
        base.OnStartClient();

        // Initially hide buttons for clients
        
        buttons[0] = redTeam;
        buttons[1] = blueTeam;

        foreach(Button button in buttons)
        {
            
                button.gameObject.SetActive(false);
            
        }

        
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        Debug.Log("it updated");
        // When client is set as local, enable buttons
        //redTeam.gameObject.SetActive(true);
        //blueTeam.gameObject.SetActive(true);
        foreach(Button button in buttons)
        {
            
                button.gameObject.SetActive(true);
                button.onClick.RemoveAllListeners();
            
        }

        

        // Add listeners
        //redTeam.onClick.RemoveAllListeners();
        redTeam.onClick.AddListener(OnClickT1);

       // blueTeam.onClick.RemoveAllListeners();
        blueTeam.onClick.AddListener(OnClickT2);
    }

    public void OnClickT1()
    {

        int i = Random.Range(0, t1spawns.Length);
        NetworkIdentity[] netobjects = new NetworkIdentity[100];

        netobjects = GameObject.FindObjectsOfType<NetworkIdentity>();
        
        for (int z = 0; z < netobjects.Length; z++)
        {
            if (netobjects[z].gameObject.transform.position == t1spawns[i].transform.position)
            {
                OnClickT1();
                return;
            }
        }
        this.GetComponent<CharacterMovement>().startingpoint = t1spawns[i].transform.position;

        this.transform.position = this.GetComponent<CharacterMovement>().startingpoint;
        this.transform.rotation = this.GetComponent<CharacterMovement>().startingrotation;


        // Clicked red team (team nr 0)
        CmdSelectTeam(1);
        Debug.Log("clicked team 1");
        redTeam.gameObject.SetActive(false);
        blueTeam.gameObject.SetActive(false);
        //black.GetComponent<SkinnedMeshRenderer>().sharedMaterial.mainTexture = sailor.material.mainTexture;

    }
    
    public void OnClickT2()
    {


        int i = Random.Range(0, t2spawns.Length);
        NetworkIdentity[] netobjects = new NetworkIdentity[100];

        netobjects = GameObject.FindObjectsOfType<NetworkIdentity>();
            for(int z=0; z<netobjects.Length; z++)
        {
            if(netobjects[z].gameObject.transform.position == t2spawns[i].transform.position)
            {
                OnClickT2();
            }
        }
            this.GetComponent<CharacterMovement>().startingpoint = t2spawns[i].transform.position;

            this.transform.position = this.GetComponent<CharacterMovement>().startingpoint;
            this.transform.rotation = this.GetComponent<CharacterMovement>().startingrotation;






        // Clicked blueteam (team nr 1)
        CmdSelectTeam(2);
        Debug.Log("clicked team 2");
        redTeam.gameObject.SetActive(false);
        blueTeam.gameObject.SetActive(false);
        //this.GetComponent<setuplocalplayer>().pname = GUI.TextField(new Rect(25, Screen.height - 40, 100, 30), this.GetComponent<setuplocalplayer>().pname); ;
       
        

    }

    
   
   
    [Command]
    public void CmdSelectTeam(int teamIndex)
    {
        
        // Set team of player on the server.
        teamid = teamIndex;
        Debug.Log(teamid);

    }
    bool reset=false;
    private void Update()
    {
        if (isLocalPlayer && puiholder.GetComponent<PlayerUI>().resettimer <= 9.5f)
        {
            reset = false;
        }
        else if (isLocalPlayer && puiholder.GetComponent<PlayerUI>().resettimer >= 9.5f && reset == false)
        {
            reset = true;
            restartinggame();
        }
        
    }

}