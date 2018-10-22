using UnityEngine;
using System.Collections;




public class CharacterMovementMine : MonoBehaviour
{
    
    GameObject clone;
    public GameObject bomb;
    GameObject objattachedto;
    Animator anim;
    GameObject boxxy;
    public bool boxiscolliding;
    public GameObject player;
    public Vector3 startingpoint;
    attachplayer ap;
    Rigidbody rb;
	public int points = 0;
    
    bool threw;
    void throwbomb()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            clone = Instantiate(bomb, new Vector3(this.transform.localPosition.x, this.transform.localPosition.y+1.5f, this.transform.localPosition.z), transform.localRotation); //the clone variable holds our instantiate action
            Rigidbody clonerb = clone.GetComponent<Rigidbody>();
            
            clonerb.AddRelativeForce(Vector3.forward * 500);
            
        }
       
            
        
    }
    public GameObject Controller;
    void Start()
    {

        startingpoint = player.GetComponent<MazeConstructor>().startpoint;
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

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Coin")) 
		{
			points += 1;
			other.gameObject.SetActive (false);
		}	
        if (other.gameObject.CompareTag("Treasure"))
        {
            points += 1;
            this.transform.position = new Vector3(0,0,0);
            Destroy(GameObject.FindGameObjectWithTag("Treasure"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure1"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure2"));
            Destroy(GameObject.FindGameObjectWithTag("Maze"));
        }
        if (other.gameObject.CompareTag("Treasure1"))
        {
            points += 1;
            this.transform.position = new Vector3(0, 0, 0);
            Destroy(GameObject.FindGameObjectWithTag("Treasure"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure1"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure2"));
            Destroy(GameObject.FindGameObjectWithTag("Maze"));
        }
        if (other.gameObject.CompareTag("Treasure2"))
        {
            points += 1;
            this.transform.position = new Vector3(0, 0, 0);
            Destroy(GameObject.FindGameObjectWithTag("Treasure"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure1"));
            Destroy(GameObject.FindGameObjectWithTag("Treasure2"));
            Destroy(GameObject.FindGameObjectWithTag("Maze"));
        }

    }

	private void OnGUI()
	{
		GUI.Label(new Rect(10, 10, 100, 20), "Score : " + points);

		if (points >= 30)
		{
			GUI.Label(new Rect(100, 100, 100, 20), "YOU WIN");
		}
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


        throwbomb();
       
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
            if (Input.GetKey(KeyCode.RightShift) || (Input.GetKey(KeyCode.LeftShift)))
        {
            z = Input.GetAxis("Vertical") * Time.deltaTime * 8.0f;
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
