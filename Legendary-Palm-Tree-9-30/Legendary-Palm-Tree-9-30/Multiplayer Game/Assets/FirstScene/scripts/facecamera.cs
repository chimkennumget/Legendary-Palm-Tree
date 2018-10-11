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
        this.transform.localEulerAngles = new Vector3(0, 0, 0);
        
    }
}
