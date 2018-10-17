using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerUI : MonoBehaviour {
    [SerializeField]
    GameObject scoreboard;
    [SerializeField]
    GameObject endgame;
    GameObject itemGO;
    [SerializeField]
    GameObject endgameboard;
    [SerializeField]
    Transform endgamemsgfield;
    public int scorelimit;
    
    
    GameObject[] PlayersG = new GameObject[8];
    bool sbshown = false;
    // Use this for initialization
    private void Start()
    {
        findeveryone();
    }
    void findeveryone()
    {
       
        int i = 0;
        for (i = 0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            PlayersG[i] = GameObject.FindGameObjectsWithTag("Player")[i];
        }
      



    }
    int LCIkills = 0;
    int LCAkills = 0;
    void updatescore()
    {
        LCIkills = 0;
        LCAkills = 0;
        foreach (GameObject player in PlayersG)
        {
            if (player != null)
            {
                if (player.GetComponent<MyLobbyPlayer>().teamid == 1)
                {
                    LCIkills += player.GetComponent<CharacterMovement>().kills;
                }
                else if (player.GetComponent<MyLobbyPlayer>().teamid == 2)
                {
                    LCAkills += player.GetComponent<CharacterMovement>().kills;
                }
            }
        }
        if (LCAkills >= scorelimit && LCAkills>LCIkills || LCIkills >= scorelimit && LCIkills>LCAkills)
        {
            print("someone is winning");
            victorycheck();
        }
    }

    bool startresettimer;
    void victorycheck()
    {

        endgameboard.SetActive(true);
        scoreboard.SetActive(false);
        GameObject itemGOI = Instantiate(endgame, endgamemsgfield);
        EndGame item = itemGOI.GetComponent<EndGame>();
        itemGO = itemGOI;
        if (item != null)
        {
            print("something should be here");
            item.endgamemsg(LCIkills, LCAkills,scorelimit);
        }
        startresettimer = true;


    }
    float waittimer = 0;
    public float resettimer = 0;
	// Update is called once per frame
    
	void LateUpdate () {
		if(Input.GetKeyDown(KeyCode.Alpha1)&& sbshown == false)
        {
            scoreboard.SetActive(true);
            sbshown = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            scoreboard.SetActive(false);
            sbshown = false;
        }
        waittimer += Time.deltaTime;
        if (waittimer > 1 && itemGO == null)
        {
           
            findeveryone();
            updatescore();
           
            waittimer = 0;
            
        }
        if (startresettimer)
        {
            waittimer = 0;
            resettimer += Time.deltaTime;
        }
        if (resettimer > 10)
        {
            foreach (Transform child in endgamemsgfield)
            {
                Destroy(child.gameObject);
            }
            resettimer = 0;
            startresettimer = false;
            itemGO = null;//allow for victory timer to check things again
            Destroy(itemGO);//get rid of instantiated text
            endgameboard.SetActive(false);
            foreach (GameObject player in PlayersG)
            {
                if (player != null)
                {
                    player.transform.position = player.GetComponent<CharacterMovement>().initialpoint;
                    player.GetComponent<CharacterMovement>().kills = 0;
                    player.GetComponent<CharacterMovement>().deaths = 0;
                    //player.GetComponent<MyLobbyPlayer>().teamid = 0;
                    //    player.GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(false);
                    //    player.GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(false);
                    
                    
                    //    player.GetComponent<MyLobbyPlayer>().blueTeam.gameObject.SetActive(true);
                    //    player.GetComponent<MyLobbyPlayer>().blueTeam.onClick.RemoveAllListeners();
                    //    player.GetComponent<MyLobbyPlayer>().redTeam.gameObject.SetActive(true);
                    //    player.GetComponent<MyLobbyPlayer>().redTeam.onClick.RemoveAllListeners();

                    



                    //// Add listeners
                    ////redTeam.onClick.RemoveAllListeners();
                    //player.GetComponent<MyLobbyPlayer>().redTeam.onClick.AddListener(player.GetComponent<MyLobbyPlayer>().OnClickT1);

                    //// blueTeam.onClick.RemoveAllListeners();
                    //player.GetComponent<MyLobbyPlayer>().blueTeam.onClick.AddListener(player.GetComponent<MyLobbyPlayer>().OnClickT2);
                    
                }

            }
        }
	}
}
