using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabrigidbodies : MonoBehaviour
{

    bool canattach;
    bool isattached;
    Rigidbody pickupbody;
    // Use this for initialization
    void Start()
    {
        canattach = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>() == true)
        {
            Debug.Log(other.transform.localScale.x);
            pickupbody = other.GetComponent<Rigidbody>();
            canattach = true;
            if (Input.GetKeyDown(KeyCode.E) && isattached)
            {

                isattached = false;
                other.transform.parent = null;

            }
            else if (Input.GetKeyDown(KeyCode.E) && canattach)
            {
                isattached = true;
                
                
            }
            if (isattached)
            {
                other.transform.parent = this.transform;                
                other.transform.rotation = this.transform.rotation;
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canattach = false;
        isattached = false;
        other.transform.parent = null;
    }
    

}
	


