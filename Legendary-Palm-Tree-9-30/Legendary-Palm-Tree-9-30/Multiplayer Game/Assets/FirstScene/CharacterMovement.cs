using UnityEngine;
using System.Collections;




public class CharacterMovement : MonoBehaviour
{
    GameObject objattachedto;
    Animator anim;
    GameObject boxxy;
    public bool boxiscolliding;
    public GameObject player;
    Vector3 startingpoint;
    attachplayer ap;
    Rigidbody rb;
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
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            objattachedto = collision.gameObject;
            Debug.Log("onground");
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
