using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class attachplayer : NetworkBehaviour {

    GameObject player;
    
    private void Start()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.transform.parent = transform;
           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject==player)
        {
           
            player.GetComponent<CharacterMovementMine>().wasattached = true;
            //other.gameObject.GetComponent<CharacterMovement>().zairspeed = this.GetComponent<updatecubeposition>().currentspeed.z;
            //other.gameObject.GetComponent<CharacterMovement>().xairspeed = this.GetComponent<updatecubeposition>().currentspeed.x;
            //other.gameObject.GetComponent<CharacterMovement>().yairspeed = this.GetComponent<updatecubeposition>().currentspeed.y;
            player.transform.parent = null;
            

        }
    }
    private void Update()
    {
        
    }
}
