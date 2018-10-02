using UnityEngine;
using System.Collections;




public class CharacterMovement : MonoBehaviour
{
    
    Animator anim;
    GameObject boxxy;
    bool boxiscolliding;
   
    Vector3 startingpoint;
  
    void Start()
    {
       
        startingpoint = gameObject.transform.position;
        anim = this.GetComponent<Animator>();
        boxxy = GameObject.Find("Cube");
        this.GetComponent<Rigidbody>().freezeRotation = true;
    }


    public bool wasmoving = false;
    public bool wasattached = false;
    public float airspeed;
    public float xairspeed=0;
    public float yairspeed=0;
    public float zairspeed=0;
    public void charjump()
    {
        if (z > 0 || z<0)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(z, 350, 0));
            airspeed = z;
            wasmoving = true;
            
            

        }
        else
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 350, 0));
        }
            
        
        boxiscolliding = false;
        
        anim.SetBool("jumping", true);
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            boxiscolliding = true;
            wasmoving = false;
            wasattached = false;
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
        else if (boxiscolliding)
        {
            transform.Rotate(0, x, 0);

            transform.Translate(0, 0, z);
        }
        if (wasmoving)
        {
            transform.Translate(0,0, airspeed);
        }
        if (wasattached)
        {
            transform.localPosition += new Vector3(xairspeed, yairspeed, zairspeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && boxiscolliding)
        {
            charjump();
           
        }
        else if (boxiscolliding==true)
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
