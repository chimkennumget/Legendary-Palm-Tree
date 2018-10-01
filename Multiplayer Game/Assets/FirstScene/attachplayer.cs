using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class attachplayer : NetworkBehaviour {
    
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
            other.gameObject.transform.parent = null;
            //other.gameObject.GetComponent<Rigidbody>().velocity= new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x,
            //    gameObject.GetComponent<Rigidbody>().velocity.y+other.gameObject.GetComponent<Rigidbody>().velocity.y, gameObject.GetComponent<Rigidbody>().velocity.x);
            
        }
    }
}
