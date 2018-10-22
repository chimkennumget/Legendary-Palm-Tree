using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Playerscoreboarditem : MonoBehaviour {
    [SerializeField]
    Text usernametext;

    [SerializeField]
    Text killstext;

    [SerializeField]
    Text deathstext;

    public void setup(string username, int kills, int deaths)
    {
        usernametext.text = username;
        killstext.text = "kills: " + kills;
        deathstext.text = "deaths: " + deaths;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
