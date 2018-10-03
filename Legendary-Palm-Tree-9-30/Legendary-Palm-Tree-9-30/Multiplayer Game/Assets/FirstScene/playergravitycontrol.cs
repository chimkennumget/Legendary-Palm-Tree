using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class playergravitycontrol : MonoBehaviour {
    public GameObject player;
    public bool rightsideup;
    public bool upsidedown;
    public bool onforwardwall;
    public bool onbackwardswall;
    public bool onleftsidewall;
    public bool onrightsidewall;
    
    Quaternion playerrot;
    Rigidbody rigid;
    public GameObject playername;
    public ConstantForce gravity;
    int listsize = 6;

    // Use this for initialization
    void Start () {
        rightsideup = true;
       
        rigid = this.GetComponent<Rigidbody>();//grab rigidbody component
        rigid.useGravity = false;//deactivate rigidbody gravity
        gravity = gameObject.AddComponent<ConstantForce>();//create constant force to relpace gravity acting on character
        gravity.force = new Vector3(0.0f, -9.81f, 0.0f);//set initial gravity
    }
    void attachforwardwall()
    {
        if (!onforwardwall)
        {
            

                    this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = -350;

            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, 90);
            //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(9.81f, 0, 0.0f);
            rightsideup = false; upsidedown = false; onbackwardswall = false; onforwardwall = true; onleftsidewall = false; onrightsidewall = false;
        }

      
    }
    void attachleftwall()
    {
        if (!onleftsidewall)
        {


            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = -350;

            this.transform.eulerAngles = new Vector3(-90, this.transform.rotation.y, this.transform.rotation.z);
            //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0, 0, 9.81f);
            rightsideup = false; upsidedown = false; onbackwardswall = false; onforwardwall = false; onleftsidewall = true; onrightsidewall = false;
        }


    }
    void attachrightwall()
    {
        if (!onrightsidewall)
        {


            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = -350;

            this.transform.eulerAngles = new Vector3(90, this.transform.rotation.y, this.transform.rotation.z);
            //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0, 0, -9.81f);
            rightsideup = false; upsidedown = false; onbackwardswall = false; onforwardwall = false; onleftsidewall = false; onrightsidewall = true;
        }


    }
    void attachbackwall()
    {
        if (!onbackwardswall)
        {
            
            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = -350;

            this.transform.eulerAngles = new Vector3(this.transform.rotation.x, this.transform.rotation.y, -90);
            //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(-9.81f, 0, 0.0f);
            rightsideup = false; upsidedown = false; onbackwardswall = true; onforwardwall = false; onleftsidewall = false; onrightsidewall = false;
        }


    }
    void flipupsidedown()
    {

        if (!upsidedown)
        {
            
            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = -350;

            this.transform.eulerAngles = new Vector3(180, this.transform.rotation.y, this.transform.rotation.z);
            //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0.0f, 9.81f, 0.0f);
            rightsideup = false; upsidedown = true; onbackwardswall = false; onforwardwall = false; onleftsidewall = false; onrightsidewall = false;

        }
    }
    void fliprightsideup()
    {
        if (!rightsideup)
        {
            
            player.GetComponent<CharacterMovement>().enabled = false;
            this.transform.Translate(0, 1, 0);
            player.GetComponent<CharacterMovement>().jumpforce = 350;

            this.transform.eulerAngles = new Vector3(0, this.transform.rotation.y, this.transform.rotation.z);
            //playername.transform.rotation = new Quaternion(0, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            gravity.force = new Vector3(0.0f, -9.81f, 0.0f);
            rightsideup = true; upsidedown = false; onbackwardswall = false; onforwardwall = false; onleftsidewall = false; onrightsidewall = false;
            player.GetComponent<CharacterMovement>().enabled = true;
        }
    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1))            
        {
            //player.GetComponent<CharacterMovement>().boxiscolliding = false;
            flipupsidedown();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //player.GetComponent<CharacterMovement>().boxiscolliding = false;
            fliprightsideup();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            //player.GetComponent<CharacterMovement>().boxiscolliding = false;
            attachforwardwall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
           // player.GetComponent<CharacterMovement>().boxiscolliding = false;
            attachbackwall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            // player.GetComponent<CharacterMovement>().boxiscolliding = false;
            attachleftwall();
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            // player.GetComponent<CharacterMovement>().boxiscolliding = false;
            attachrightwall();
        }




    }
}
