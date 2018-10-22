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

    GameObject playerui;
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
    public TextMesh LCIscore;
    public TextMesh LCAscore;
    public int LCIbonus;
    public int LCAbonus;
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
        LCIkills += LCIbonus;
        LCAkills += LCAbonus;

        LCIscore.text = "LCI: " + LCIkills;
        
        LCAscore.text = "LCA: " + LCAkills;

        if (LCAkills >= scorelimit && LCAkills>LCIkills || LCIkills >= scorelimit && LCIkills>LCAkills)
        {
            print("someone is winning");
            victorycheck();
        }
    }

    public bool startresettimer;
    void victorycheck()
    {
        
        endgameboard.SetActive(true);
        scoreboard.SetActive(false);
        GameObject itemGOI = Instantiate(endgame, endgamemsgfield);
        EndGame item = itemGOI.GetComponent<EndGame>();
        itemGO = itemGOI;
        if (itemGO != null)
        {
            print("something should be here");
            item.endgamemsg(LCIkills, LCAkills,scorelimit);
        }
        foreach(GameObject pui in GameObject.FindGameObjectsWithTag("pui"))
        {
            pui.GetComponent<PlayerUI>().startresettimer = true;
        }
        


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
        if (waittimer > 2 && itemGO == null)
        {
           
            findeveryone();
            updatescore();
           
            waittimer = 0;
            
        }
        if (startresettimer)
        {
            
            waittimer = 0;
            resettimer += Time.deltaTime;
           GetComponent<PlayerUI>().LCIbonus = 0;
           GetComponent<PlayerUI>().LCAbonus = 0;
           GetComponent<PlayerUI>().LCIkills = 0;
           GetComponent<PlayerUI>().LCAkills = 0;
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
                    scoreboard.GetComponent<Scoreboard>().LCIbonus = 0;
                    scoreboard.GetComponent<Scoreboard>().LCAbonus = 0;
                    
                    Debug.Log("kills" + player.GetComponent<CharacterMovement>().kills);
                    player.GetComponent<CharacterMovement>().deaths = 0;
                    Debug.Log("deaths" + player.GetComponent<CharacterMovement>().deaths);
                   

                }

            }
            
            }
        }
	}


