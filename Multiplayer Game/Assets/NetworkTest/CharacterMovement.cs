using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;



public class CharacterMovement : MonoBehaviour
{
    
    Animator anim;
    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        
            var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
            var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * 3.0f;

            transform.Rotate(0, x, 0);
            transform.Translate(0, 0, z);
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
