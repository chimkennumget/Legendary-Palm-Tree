using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Networking;
public class Scoreboard : MonoBehaviour {
    [SerializeField]
    GameObject playerscoreboarditemprefab;
    [SerializeField]
    Transform playerscoreboardlist;
    [SerializeField]
    GameObject teamscoreboardprefab;
    GameObject[] Players = new GameObject[8];
    public static GameObject[] PlayersG = new GameObject[8];
    public int LCIScore;
    public int LCASCore;
    void OnEnable()
    {
        findeveryone();
        updateteamscores(PlayersG);
        updateplayerscores(PlayersG);

    }
    void findeveryone()
    {
        Debug.Log(GameObject.FindGameObjectsWithTag("Player").Length);
        int i = 0;
        for (i=0; i < GameObject.FindGameObjectsWithTag("Player").Length; i++)
        {
            PlayersG[i] = GameObject.FindGameObjectsWithTag("Player")[i];
        }
        //foreach (GameObject go in GameObject.FindGameObjectsWithTag("Player"))
        //{
        //    PlayersG[i] = go;
        //    i++;
        //}
        for(int y=0; y < PlayersG.Length; y++)
        {
            print(PlayersG[y]);
        }
      

        
    }
    public int LCIbonus;
    public int LCAbonus;
    void updateteamscores(GameObject[] players)
    {
        int LCIkills = 0;
        int LCAkills = 0;
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
        
            GameObject itemGO = Instantiate(teamscoreboardprefab, playerscoreboardlist);
            Teamscoreboarditem item = itemGO.GetComponent<Teamscoreboarditem>();
            if (item != null)
            {
                item.setupteamkills(LCIkills,LCAkills);
            }
        

    }

    void updateplayerscores(GameObject[] players)
    {
        foreach(GameObject player in PlayersG)
        {
            if (player != null)
            {
                GameObject itemGO = Instantiate(playerscoreboarditemprefab, playerscoreboardlist);
                Playerscoreboarditem item = itemGO.GetComponent<Playerscoreboarditem>();
                if (item != null)
                {
                    item.setup(player.GetComponent<setuplocalplayer>().pname, player.GetComponent<CharacterMovement>().kills, player.GetComponent<CharacterMovement>().deaths);
                }
            }
        }
    }
    
    void OnDisable()
    {
        PlayersG = new GameObject[8];
        Debug.Log(PlayersG[0]);
        foreach(Transform child in playerscoreboardlist)
        {
            Destroy(child.gameObject);
        }
    }
  

}
