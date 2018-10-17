using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Teamscoreboarditem : MonoBehaviour {
    [SerializeField]
    Text LCIkillstext;

    [SerializeField]
    Text LCAkillstext;

    [SerializeField]
    Text leadingteamstext;

    public void setupteamkills(int lcikills, int lcakills)
    {
        LCIkillstext.text = "LCI kills: " + lcikills;
        LCAkillstext.text = "LCA kills: " + lcakills;

        if (lcikills - 10 >= lcakills)
        {
            leadingteamstext.text = "The LCI is Eviscerating the LCA";
        }
        else if (lcakills - 10 >= lcikills)
        {
            leadingteamstext.text = "The LCA is Eviscerating the LCI";
        }
        else if (lcikills - 5 >= lcakills)
        {
            leadingteamstext.text = "The LCI is Dominating";
        }
        else if (lcakills - 5 >= lcikills)
        {
            leadingteamstext.text = "The LCA is Dominating";
        }
        else if (lcikills > lcakills)
        {
            leadingteamstext.text = "The LCI is winning";
        }
        else if (lcakills > lcikills)
        {
            leadingteamstext.text = "The LCA is winning";
        }
        else if (lcakills == lcikills)
        {
            leadingteamstext.text = "STANDOFF";
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
