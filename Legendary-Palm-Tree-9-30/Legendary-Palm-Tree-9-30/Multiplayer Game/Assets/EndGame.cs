using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EndGame : MonoBehaviour {
    [SerializeField]
    Text endgametext;
    
 
    private void Start()
    {
       
    }
    public void endgamemsg(int lcikills, int lcakills,int scorelimit)
    {
        if (lcikills > lcakills && lcikills >= scorelimit)
        {
            endgametext.text = "ツンデレ・ロリス勝利. Bow before their cuteness";
        }
        else if (lcakills > lcikills && lcakills >= scorelimit)
        {
            endgametext.text = "ヤンダレロリス勝利. Run from their jealousy";
        }
    }

}
