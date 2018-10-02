using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facecamera : MonoBehaviour {
    public Camera charactercamera;
	// Update is called once per frame
	void Update () {
        this.transform.LookAt(charactercamera.transform.position);
        this.transform.Rotate(new Vector3(0, 180, 0));
    }
}
