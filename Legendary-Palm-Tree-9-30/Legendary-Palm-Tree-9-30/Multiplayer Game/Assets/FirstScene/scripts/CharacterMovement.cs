using UnityEngine;
using UnityEngine.Networking;
using System.Collections;




public class CharacterMovement : NetworkBehaviour
{
    
    GameObject clone;
    public GameObject bomb;
    GameObject objattachedto;
    Animator anim;
    GameObject boxxy;
    public bool boxiscolliding;
    public GameObject player;
    Vector3 startingpoint;
    attachplayer ap;
    Rigidbody rb;
    
    bool threw;
    
    [Command]
    void Cmdthrowbomb()
    {

            GameObject clone = Instantiate(bomb, new Vector3(this.transform.localPosition.x, this.transform.localPosition.y+1.5f, this.transform.localPosition.z), transform.localRotation) as GameObject; //the clone variable holds our instantiate action
            clone.GetComponent<Rigidbody>().isKinematic = false;
            Rigidbody clonerb = clone.GetComponent<Rigidbody>();
            clonerb.AddRelativeForce(Vector3.forward * 800);
            NetworkServer.Spawn(clone);
        
    }
    
    void Start()
    {
        
        startingpoint = gameObject.transform.position;
        anim = this.GetComponent<Animator>();
        boxxy = GameObject.Find("Cube");
        rb = this.GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotationY;
        
    }


    public bool wasmoving = false;
    public bool wasattached = false;
    public float airspeed;
    public float xairspeed=0;
    public float yairspeed=0;
    public float zairspeed=0;
    public float jumpforce =350;
    public void charjump()
    {
        
            gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, jumpforce, 0));
            airspeed = z;
            wasmoving = true;
 
        anim.SetBool("jumping", true);
        
    }
    
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject)
        {
            objattachedto = collision.gameObject;

            boxiscolliding = true;
            wasmoving = false;
            wasattached = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject)
        {
            Debug.Log("in the air");
            boxiscolliding = false;
        }
    }

    public float x;
     public float z;


    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Q))
        {
            Cmdthrowbomb();
        }

            if (gameObject.transform.position.y <= -20)
            {

                gameObject.transform.position = startingpoint;
            }

            x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;
            if ((Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift)) && boxiscolliding)
            {

                transform.Translate(-5 * Time.deltaTime, 0, 0);
            }
            else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift) && boxiscolliding)
            {

                transform.Translate(5 * Time.deltaTime, 0, 0);
            }


        //if (anim.GetBool("jumping")==false)
        //{
            transform.Translate(0, 0, z);
        //}
            
            transform.Rotate(0, x, 0);
            
            if (wasmoving)
            {
                transform.Translate(0, 0, airspeed);
            }
            if (wasattached)
            {
                transform.Translate(xairspeed, yairspeed, zairspeed, objattachedto.transform);
            }

            if (Input.GetKeyDown(KeyCode.Space) && anim.GetBool("jumping")==false)
            {
            Debug.Log("jump");
                charjump();

            }
            else if (boxiscolliding == true)
            {
                anim.SetBool("jumping", false);
            }
            if (z > 0)
            {

                anim.SetBool("running", true);
            }
            else if (z < 0)
            {


                anim.SetBool("backstepping", true);

            }
            else
            {

                anim.SetBool("running", false);
                anim.SetBool("backstepping", false);
            }
        
        
    }
   
    
}
