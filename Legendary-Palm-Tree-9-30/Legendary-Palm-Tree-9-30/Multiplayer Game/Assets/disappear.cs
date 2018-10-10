using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour {
    public GameObject activator;//game object to check color and do something based off that
    public GameObject firstpillar;
    float resettimer=0;
    bool runtimer;
	// Use this for initialization
	void Start () {
        firstpillar.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (activator.GetComponent<MeshRenderer>().material.color == Color.red)
        {
            Debug.Log("it's red");
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            //firstpillar.SetActive(true);
            runtimer = true;
        }
            if (runtimer)
            {
                resettimer += Time.deltaTime;
                if (resettimer > 9)
                {

                    this.GetComponent<MeshRenderer>().enabled = true;
                    this.GetComponent<BoxCollider>().enabled = true;
                    //firstpillar.SetActive(false);
                    runtimer = false;
                    resettimer = 0;
                }
            }
           
            
        
	}
}
