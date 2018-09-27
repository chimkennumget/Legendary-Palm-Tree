using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
// A playerUnit is a unit controlled by a player
//could be character in FPS, zergling in a RTS
//Or a scout in a TBS

public class PlayerUnit : NetworkBehaviour {

    
   
    // Use this for initialization
    void Start()
    {

        
    }



    float speed=50;
    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        gameObject.GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
       
        //this function runs on ALL PlayerUnits -- not just the ones that I own.
        //How do I verify that I am allowed to mess with this object?
        // if (isLocalPlayer == false)
        if (hasAuthority == false)
        {
            return;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.Translate(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Destroy(gameObject);
            Debug.Log("destroyed");
            //DestroyImmediate(Camera.main.gameObject);
           // Camera.main.enabled = false;
        }
        //if (Input.GetKeyDown(KeyCode.UpArrow))
        //{
        //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, thrust, ForceMode.Acceleration);
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow))
        //{
        //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(0, 0, -thrust, ForceMode.Acceleration);
        //}
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        //{
        //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(-thrust, 0, 0, ForceMode.Acceleration);
        //}
        //if (Input.GetKeyDown(KeyCode.RightArrow))
        //{
        //    gameObject.GetComponent<Rigidbody>().AddRelativeForce(thrust, 0, 0, ForceMode.Acceleration);
        //}
    }
}
