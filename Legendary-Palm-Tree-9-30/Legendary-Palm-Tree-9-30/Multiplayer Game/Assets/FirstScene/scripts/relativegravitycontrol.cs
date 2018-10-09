using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class relativegravitycontrol : MonoBehaviour
{

    public GameObject player;//reference to ourselves

    int i = 0;
    
    Rigidbody rigid;//reference to our rigidbody
    public GameObject playername;//reference to playername
    public ConstantForce gravity;//sets up gravity of player
    

    // 
    void Start()
    {
        

        rigid = this.GetComponent<Rigidbody>();//grab rigidbody component
        rigid.useGravity = false;//deactivate rigidbody gravity
        gravity = gameObject.AddComponent<ConstantForce>();//create constant force to replace gravity acting on character
        gravity.relativeForce = new Vector3(0.0f, -9.81f, 0.0f);//set initial gravity
    }
    
        
    //adjusts gravity relative to players left side and rotates them
    void gravityleftchange()
    {



        this.transform.Translate(0, 1, 0);
        //player.GetComponent<CharacterMovement>().jumpforce = -350;

        this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z - 90);
        //playername.transform.rotation = new Quaternion(180, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
        gravity.relativeForce = new Vector3(0, -9.81f, 0.0f);



    }
    //adjusts gravity relative to players right side and rotates them
    void gravityrightchange()
    {
        this.transform.Translate(0, 1, 0);
        

        this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z + 90);
        
    }
    //changing on x axis has weird issues so alternative code is required but this changes gravity to forward of current orientation and rotates character
    void gravityforwardchange()
    {
        this.transform.Translate(0, 1, 0);


        //this.transform.localEulerAngles = new Vector3(this.transform.localEulerAngles.x + 89, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        transform.RotateAround(transform.position, -transform.right,  90f);
    }
    //changing on x axis has weird issues so alternative code is required changes gravity to backwards of current orientation and rotates character
    void gravitybackwardchange()
    {
        this.transform.Translate(0, 1, 0);
        
        //this.transform.localEulerAngles =  new Vector3(xaxis + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        transform.RotateAround(transform.position, transform.right, 90);


    }
    //flips gravity upsidedown relative to current orientation and rotates character
    void gravityflipchange()
    {
        
            this.transform.Translate(0, 1, 0);
        
            this.transform.localEulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, this.transform.localEulerAngles.z + 180);
        
    }
    //checks for continuous collisions and sends out a sphere cast to normalize player rotation to the surface normal so they always adjust to be standing
    private void OnCollisionStay(Collision collision)
    {
        
           // Debug.Log("isnormal");
            RaycastHit hit;
            if (Physics.SphereCast(transform.position, 0.1f, -transform.up, out hit, .02f))
            //if (Physics.Raycast(transform.position, -transform.up, out hit, 1))
            {
                transform.localRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                //transform.localRotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal), hit.normal), Time.deltaTime * 500.0f);
            }
        
    }
    //checks for key presses to run to related gravity change functions if player is not in the air
    private void LateUpdate()
    {
        if (player.GetComponent<CharacterMovement>().boxiscolliding == true)
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
            if (Input.GetKeyDown(KeyCode.V) || Input.GetKeyDown(KeyCode.B))
            {
                gravitybackwardchange();
            }
            if (Input.GetKeyDown(KeyCode.G))
            {
                gravityflipchange();
            }
        }

    }
}
