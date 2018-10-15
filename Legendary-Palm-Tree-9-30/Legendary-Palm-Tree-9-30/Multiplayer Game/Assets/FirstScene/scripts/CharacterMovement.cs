using UnityEngine;
using UnityEngine.Networking;
using System.Collections;




public class CharacterMovement : NetworkBehaviour
{
    
    public GameObject bombspawn;
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
   
    //[SyncVar(hook ="serversetblueteam")]
    //public bool blueteam=false;

    //[SyncVar(hook = "serversetredteam")]
   // public bool redteam=false;
    bool threw;
    //void serversetredteam(bool rt)
    //{
    //    if (rt)
    //    {
    //        this.redteam = true;
    //    }
    //    else
    //    {
    //        this.redteam = false;
    //    }
    //}
    //void serversetblueteam(bool bt)
    //{
    //    if (bt)
    //    {
    //        this.blueteam = true;
    //    }
    //    else
    //    {
    //        this.blueteam = false;
    //    }
    //}
    
   
    [Command]
    void Cmdthrowbomb()
    {
        //Rpcthrowbomb();
        GameObject clone = Instantiate(bomb, bombspawn.transform.position, transform.localRotation) as GameObject; //the clone variable holds our instantiate action
        clone.GetComponent<Rigidbody>().isKinematic = false;

        clone.GetComponent<explodebomb>().throwerid = this.GetComponent<MyLobbyPlayer>().teamid;


        Rigidbody clonerb = clone.GetComponent<Rigidbody>();
        clonerb.AddRelativeForce(Vector3.forward * 800);
        NetworkServer.Spawn(clone);
        Debug.Log("spawned it");

    }
    [ClientRpc]
    void Rpcthrowbomb()
    {

        GameObject clone = Instantiate(bomb, bombspawn.transform.position, transform.localRotation) as GameObject; //the clone variable holds our instantiate action
        clone.GetComponent<Rigidbody>().isKinematic = false;

        clone.GetComponent<explodebomb>().throwerid = this.GetComponent<MyLobbyPlayer>().teamid;


        Rigidbody clonerb = clone.GetComponent<Rigidbody>();
        clonerb.AddRelativeForce(Vector3.forward * 800);
        NetworkServer.Spawn(clone);
        Debug.Log("spawned it");

    }
    [Command]
    void Cmdthrowdelaybomb()
    {

        GameObject clone = Instantiate(bomb, bombspawn.transform.position, transform.localRotation) as GameObject; //the clone variable holds our instantiate action
        clone.GetComponent<Rigidbody>().isKinematic = false;
        clone.GetComponent<explodebomb>().throwerid = this.GetComponent<MyLobbyPlayer>().teamid;//consider getinstanceID for testing different teams
        Debug.Log(clone.GetComponent<explodebomb>().throwerid);
        clone.GetComponent<explodebomb>().delayexplode = true;
        Rigidbody clonerb = clone.GetComponent<Rigidbody>();
        
        NetworkServer.Spawn(clone);
        Debug.Log("spawned it");

    }
    public override void OnStartLocalPlayer()
    
    {
        player = this.gameObject;
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
    public float jumpforce =250;
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
        if (Input.GetKeyDown(KeyCode.R))
        {
            Cmdthrowdelaybomb();
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
