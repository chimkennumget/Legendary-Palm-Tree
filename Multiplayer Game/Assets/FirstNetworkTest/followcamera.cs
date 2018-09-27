using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class followcamera : NetworkBehaviour {
    
    PlayerConnectionObject pco;
    PlayerUnit pu;
    public Camera playercamera;
    Vector3 camerapos;
    GameObject cameraObject;
    GameObject myplayer;
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;
    // Use this for initialization
    void Start()
    {
        
    cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        myplayer = GameObject.Find("PlayerUnit(Clone)");
        if (cameraObject != null && GameObject.Find("PlayerUnit(Clone)"))
        {
            Debug.Log("Found it");
            cameraObject.transform.position = myplayer.transform.position + new Vector3(0,-4,0);
    camerapos = myplayer.transform.position + cameraObject.transform.position;
        }
        
        
    }
    // float thrust = 50;



    void LateUpdate()
{
        if (myplayer != null)
        {
            Vector3 newpos = myplayer.transform.position + camerapos;
            //Debug.Log(newpos);
            cameraObject.transform.position = newpos;
        }
        else
        {
            //Debug.Log("searching");
            myplayer = GameObject.Find("PlayerUnit(Clone)");
            cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
            if (cameraObject != null && GameObject.Find("PlayerUnit(Clone)"))
            {
                Debug.Log("Found it");
                cameraObject.transform.position = myplayer.transform.position + new Vector3(0, -4, 0);
                camerapos = myplayer.transform.position + cameraObject.transform.position;
            }
        }
}
}
