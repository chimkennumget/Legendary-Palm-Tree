using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;



public class CharacterMovement : MonoBehaviour
{
    
    Animator anim;
    GameObject boxxy;
    bool boxiscolliding;
    void Start()
    {
        anim = this.GetComponent<Animator>();
        boxxy = GameObject.Find("Cube");
    }
    void charjump()
    {
        
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 350, 0));
        boxiscolliding = false;
            anim.SetBool("jumping", true);
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject)
        {
            boxiscolliding = true;
        }
    }
    void Update()
    {
        
            var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 5.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
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
