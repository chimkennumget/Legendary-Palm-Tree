using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachwithrotation : MonoBehaviour {
    GameObject player;
    bool rotatewithme;
    
    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            player.transform.parent = transform;
            rotatewithme = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            rotatewithme = false;
            player.GetComponent<CharacterMovementMine>().wasattached = true;
            
            player.transform.parent = null;
            

        }
    }
    private void Update()
    {
        if (rotatewithme)
        {
            player.transform.rotation = this.transform.localRotation;
            
            
        }
        
        
    }
}
