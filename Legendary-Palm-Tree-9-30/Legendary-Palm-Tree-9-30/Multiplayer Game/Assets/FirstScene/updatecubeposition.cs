using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class updatecubeposition : MonoBehaviour {
    Vector3 returnpoint;
    public Vector3 currentspeed;
    bool changedirection;
	// Use this for initialization
	void Start () {
        returnpoint = this.transform.position;
        changedirection = false;
	}
	void movecube()
    {
        if (this.transform.position.z < returnpoint.z + 5 && changedirection == false)
        {
            this.transform.Translate(0, 0, Time.deltaTime);
            currentspeed = new Vector3(0, 0, Time.deltaTime);
        }
        else { changedirection = true; };
        if (this.transform.position.z > returnpoint.z - 5 && changedirection == true )
        {
            this.transform.Translate(0, 0, -Time.deltaTime);
            currentspeed = new Vector3(0, 0, -Time.deltaTime);
        }
        else { changedirection = false; }

    }
	// Update is called once per frame
	void Update () {
        movecube();
	}
}
