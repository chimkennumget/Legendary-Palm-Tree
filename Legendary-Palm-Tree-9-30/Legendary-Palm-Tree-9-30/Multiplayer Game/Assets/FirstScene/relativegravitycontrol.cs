using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class relativegravitycontrol : MonoBehaviour
{

    public GameObject player;
    public bool rightsideup;
    public bool upsidedown;
    public bool onforwardwall;
    public bool onbackwardswall;
    public bool onleftsidewall;
    public bool onrightsidewall;

    
    Rigidbody rigid;
    public GameObject playername;
    public ConstantForce gravity;
    int listsize = 6;

    // Use this for initialization
    void Start()
    {
        rightsideup = true;

        rigid = this.GetComponent<Rigidbody>();//grab rigidbody component
        rigid.useGravity = false;//deactivate rigidbody gravity
        gravity = gameObject.AddComponent<ConstantForce>();//create constant force to replace gravity acting on character
        gravity.relativeForce = new Vector3(0.0f, -9.81f, 0.0f);//set initial gravity
    }
    
        
    
    void gravityleftchange()
    {



        this.transform.Translate(0, 1, 0);
        //player.GetComponent<CharacterMovement>().jumpforce = -350;

        this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z - 90);
        //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        gravity.relativeForce = new Vector3(0, -9.81f, 0.0f);



    }
    void gravityrightchange()
    {
        this.transform.Translate(0, 1, 0);
        

        this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z + 90);
        
    }
    //changing on x axis has weird issues so alternative code is required
    void gravityforwardchange()
    {
        this.transform.Translate(0, 1, 0);


        //this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x + 89, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        transform.RotateAround(transform.position, -transform.right,  90f);
    }
    //changing on x axis has weird issues so alternative code is required
    void gravitybackwardchange()
    {
        this.transform.Translate(0, 1, 0);
        
        //this.transform.localEulerAngles =  new Vector3(xaxis + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        transform.RotateAround(transform.position, transform.right, 90);


    }
    void gravityflipchange()
    {
        this.transform.Translate(0, 1, 0);

        this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z+180);

    }
    private void OnCollisionStay(Collision collision)
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, -transform.up, out hit, 50))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal), hit.normal), Time.deltaTime * 5.0f);
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            gravityleftchange();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            gravityrightchange();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gravityforwardchange();
        }
        if (Input.GetKeyDown(KeyCode.V)|| Input.GetKeyDown(KeyCode.B))
        {
            gravitybackwardchange();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gravityflipchange();
        }


    }
}
