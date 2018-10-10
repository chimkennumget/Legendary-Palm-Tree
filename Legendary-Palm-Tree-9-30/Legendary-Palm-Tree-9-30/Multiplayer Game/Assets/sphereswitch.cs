using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sphereswitch : MonoBehaviour {
    Color startcolor;
    Color activecolor;
    float timer=0;
    public int timetowait=5;
    public bool changecolor;
    // Use this for initialization
    void Start () {
        startcolor = this.GetComponent<MeshRenderer>().material.color;
        
	}
	void switchcolor()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.red;
        timer += Time.deltaTime;
    }
    void returncolor()
    {
        this.GetComponent<MeshRenderer>().material.color = startcolor;
    }
    void activatedoor()
    {
        
        if(this.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            //do something to other object
        }
    }
	// Update is called once per frame
	void Update () {
        if (changecolor)
        {
            switchcolor();
            
        }
        if(timer>timetowait)
        {
            changecolor = false;
            timer = 0;
            returncolor();
        }
	}
}
