using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class attachplayer : NetworkBehaviour {
    
    
    updatecubeposition ucp;
    private void Start()
    {
       
    }
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
            //other.gameObject.GetComponent<CharacterMovement>().zairspeed = this.GetComponent<updatecubeposition>().currentspeed.z;
            //other.gameObject.GetComponent<CharacterMovement>().xairspeed = this.GetComponent<updatecubeposition>().currentspeed.x;
            //other.gameObject.GetComponent<CharacterMovement>().yairspeed = this.GetComponent<updatecubeposition>().currentspeed.y;
            other.gameObject.transform.parent = null;


        }
    }
}
