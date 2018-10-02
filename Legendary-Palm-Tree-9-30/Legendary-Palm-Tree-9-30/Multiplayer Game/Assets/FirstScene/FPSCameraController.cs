using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FPSCameraController : MonoBehaviour {
    public GameObject player;
    public int rightlimit = 60;
    public int leftlimit = -60;
    public int vertuplimit = 45;
    public int vertlowlimit = -25;
    int horval;
    int vertval;
    public int horspeed =1;
    public int vertspeed =1;
    Vector3 initialrotation;
    Vector3 initcamrot;
    

    private void Start()
    {
        initcamrot = this.transform.eulerAngles;
    }
    private void Update()
    {
        initialrotation = player.transform.eulerAngles;
        if (Input.GetKeyDown(KeyCode.O))
        {
            this.transform.eulerAngles = new Vector3(initialrotation.x+initcamrot.x, initialrotation.y,initialrotation.z);
            horval = 0;
            vertval = 0;
        }
        if (Input.GetKey(KeyCode.J)&& horval>leftlimit)
        {
            transform.eulerAngles +=new Vector3(0, -horspeed, 0);
            horval += -horspeed;
        }
        if (Input.GetKey(KeyCode.L) && horval < rightlimit)
        {
            transform.eulerAngles += new Vector3(0, horspeed, 0);
            horval += horspeed;
        }
        if (Input.GetKey(KeyCode.I)&& vertval < vertuplimit)
        {
            transform.eulerAngles += new Vector3(-vertspeed, 0, 0);
            vertval += vertspeed;
        }
        if (Input.GetKey(KeyCode.K) && vertval >vertlowlimit)
        {
            transform.eulerAngles += new Vector3(vertspeed, 0, 0);
            vertval += -vertspeed;
        }
    }
}




