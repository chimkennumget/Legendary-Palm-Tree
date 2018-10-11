using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallthenreset : MonoBehaviour {
    Vector3 startposition;
    Quaternion startrot;
    float resetpostimer =0;
    bool starttimer;
    bool falltimestart;
    bool changedirection=false;
    float falldelay=0;
    float rng;
    private void Start()
    {
        rng = Random.Range(.5f,1);
        startposition = this.transform.position;
        startrot = this.transform.rotation;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            falltimestart = true;
            
        }
        else
        {
            starttimer = true;
        }
    }
    void resetpos()
    {
        rng = Random.Range(.5f,1);
        this.GetComponent<Rigidbody>().isKinematic = true;
        this.transform.position = startposition;
        this.transform.rotation = startrot;
    }

    void movecube()
    {
        if (this.transform.localPosition.y < startposition.y + rng && changedirection == false)
        {
            this.transform.Translate(0, Time.deltaTime, 0);
            
        }
        else { changedirection = true; };
        if (this.transform.localPosition.y > startposition.y - rng && changedirection == true)
        {
            this.transform.Translate(0, -Time.deltaTime, 0);
            
        }
        else { changedirection = false; }

    }
    // Update is called once per frame
    void Update () {
        if (starttimer == false)
        {
            movecube(); 
            
        }
        
		if(starttimer == true)
        {
            resetpostimer += Time.deltaTime;
            if (resetpostimer > 3)
            {

                starttimer = false;
                resetpostimer = 0;
                resetpos();
            }
        }
        if (falltimestart)
        {
            falldelay += Time.deltaTime;
            if (falldelay > .5f)
            {
                this.transform.DetachChildren();
                this.GetComponent<Rigidbody>().isKinematic = false;
                falltimestart = false;
                falldelay = 0;
            }
        }
        

	}
}
