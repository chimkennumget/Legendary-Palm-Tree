using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public int points = 0; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 2, 0, Space.World);
	}

    private void OnTriggerEnter(Collider other)
    {
		if(other.name == "KadukiBlackHairPrefab 1")
        {
            // Add one to points
            Destroy(gameObject);
            other.GetComponent<characterController>().points++;
        }
    }
}
