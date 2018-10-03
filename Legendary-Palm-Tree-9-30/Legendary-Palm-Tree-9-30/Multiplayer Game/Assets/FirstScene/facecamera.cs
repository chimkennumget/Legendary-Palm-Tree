using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facecamera : MonoBehaviour {
    public GameObject player;
    public Camera charactercamera;
    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update () {
        this.transform.LookAt(charactercamera.transform.position);
        if (player.GetComponent<playergravitycontrol>().upsidedown == false)
        {
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
        if (player.GetComponent<playergravitycontrol>().upsidedown == true)
        {
            
            this.transform.Rotate(new Vector3(0, 180, 180));
        }
    }
}
