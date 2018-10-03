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
        if (player.GetComponent<playergravitycontrol>().rightsideup == true)
        {
            this.transform.Rotate(new Vector3(0, 180, 0));
        }
        if (player.GetComponent<playergravitycontrol>().upsidedown == true)
        {
            
            this.transform.Rotate(new Vector3(0, 180, 180));
        }
        if (player.GetComponent<playergravitycontrol>().onforwardwall == true)
        {

            this.transform.Rotate(new Vector3(180, 0, -90));
        }
        if (player.GetComponent<playergravitycontrol>().onbackwardswall == true)
        {

            this.transform.Rotate(new Vector3(180, 0, 90));
        }
        if (player.GetComponent<playergravitycontrol>().onleftsidewall == true)
        {

            this.transform.Rotate(new Vector3(180, 0, 0));
        }
        if (player.GetComponent<playergravitycontrol>().onrightsidewall == true)
        {

            this.transform.Rotate(new Vector3(180, 0, 180));
        }

    }
}
