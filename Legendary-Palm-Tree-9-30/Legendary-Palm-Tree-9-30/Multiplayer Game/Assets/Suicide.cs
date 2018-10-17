using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicide : MonoBehaviour {
    public GameObject Pui;
    public GameObject scoreboard;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("collided");
        if (other.gameObject.CompareTag("deathbarrier"))
        {
            transform.rotation = gameObject.GetComponent<CharacterMovement>().startingrotation;
            this.GetComponent<Rigidbody>().angularVelocity = this.GetComponent<Rigidbody>().angularVelocity * .01f;

            transform.position = gameObject.GetComponent<CharacterMovement>().startingpoint;
            Debug.Log("it has the tag");
            if (GetComponent<MyLobbyPlayer>().teamid == 1)
            {
                Debug.Log("We are running the loop");
                GetComponent<CharacterMovement>().deaths++;


                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (player != null)
                    {
                        Debug.Log("a players total scores bonus scores should be getting updated");
                         GetComponentInChildren<PlayerUI>().LCAbonus++;

                        Pui.GetComponentInChildren<Scoreboard>().LCAbonus++;
                    }
                }
            }



            else if (GetComponent<MyLobbyPlayer>().teamid == 2)
            {
                Debug.Log("team2 suicide");
                GetComponent<CharacterMovement>().deaths++;


                foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player"))
                {
                    if (player != null)
                    {
                        Debug.Log("a players total scores bonus scores should be getting updated");
                        GetComponentInChildren<PlayerUI>().LCIbonus++;

                        Pui.GetComponentInChildren<Scoreboard>().LCIbonus++;
                    }


                }
            }
        }

    }
}

    // Update is called once per frame
    

