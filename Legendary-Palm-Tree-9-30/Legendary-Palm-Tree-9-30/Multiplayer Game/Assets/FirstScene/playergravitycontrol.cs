using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class playergravitycontrol : MonoBehaviour {
    public GameObject player;
    public bool upsidedown;
    Quaternion playerrot;
    Rigidbody rigid;
    public GameObject playername;
    public ConstantForce gravity;
    public bool stoprot;

    // Use this for initialization
    void Start () {
        stoprot = false;
        rigid = this.GetComponent<Rigidbody>();//grab rigidbody component
        rigid.useGravity = false;//deactivate rigidbody gravity
        gravity = gameObject.AddComponent<ConstantForce>();//create constant force to relpace gravity acting on character
        gravity.force = new Vector3(0.0f, -9.81f, 0.0f);//set initial gravity
    }
    
    void flipupsidedown()
    {

        if (!upsidedown)
        {
            player.GetComponent<CharacterMovement>().enabled = false;
            this.transform.Translate(0, 1, 0);            
            player.GetComponent<CharacterMovement>().jumpforce = -350;
           
            this.transform.eulerAngles = new Vector3(180, this.transform.rotation.y, this.transform.rotation.z);
            playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0.0f, 9.81f, 0.0f);
            upsidedown = true;
            player.GetComponent<CharacterMovement>().enabled = true;
        }
        else
        {
            player.GetComponent<CharacterMovement>().enabled = false;
            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = 350;
            
            this.transform.eulerAngles = new Vector3(0, this.transform.rotation.y, this.transform.rotation.z);
            playername.transform.rotation = new Quaternion(0, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0.0f, -9.81f, 0.0f);
            upsidedown = false;
            player.GetComponent<CharacterMovement>().enabled = true;
        }
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1) && 
            (Input.GetKey(KeyCode.A)==false && Input.GetKey(KeyCode.D) == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) == false))
        {
            player.GetComponent<CharacterMovement>().boxiscolliding = false;
            stoprot = true;
            
            
            flipupsidedown();
        }
        if (player.GetComponent<CharacterMovement>().boxiscolliding)
        {

            stoprot = false;
        }
        
        
    }
}
