using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class attachplayer : NetworkBehaviour {
    
    
    updatecubeposition ucp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            other.gameObject.GetComponent<CharacterMovement>().wasattached = true;
            other.gameObject.GetComponent<CharacterMovement>().zairspeed = this.GetComponent<updatecubeposition>().currentspeed.z;
            other.gameObject.transform.parent = null;


        }
    }
}
