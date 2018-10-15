using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class explodebomb : NetworkBehaviour {
    
    
    GameObject explosion;
    ParticleSystem parts;
    CharacterMovement cm;
    public GameObject psholder;
    public GameObject bomb;
    public float power=40;
    public float radius=10;
    public float upforce=10;
    public float countdown=0;
    public bool delayexplode=false;
    public bool starttimer=false;
    bool destroytimer = false;
    bool hitsomething = false;
    float duration;
    float certaindeath = 0;
    public int throwerid;
    
	// Use this for initialization
	
    [ClientRpc]
    void Rpcexplosioneffect()
    {
        
        explosion = Instantiate(psholder, bomb.transform.position, bomb.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void Update () {

        
            if (starttimer)
            {
                if (delayexplode)
                {

                    countdown += Time.deltaTime;

                    if (countdown > 3)
                    {
                        countdown = 0;
                    if (hasAuthority)
                    {
                        Debug.Log("we have authority");
                        explode();
                    }
                    
                    delayexplode = false;
                        starttimer = false;
                    }
                }
                else
                {
                if (hasAuthority)
                {
                    Debug.Log("we have authority");
                    explode();
                }
                
                
                    starttimer = false;
                    countdown = 0;
                }
            }
            
            

        
        if (destroytimer)
        {

            countdown += Time.deltaTime;
            if (countdown > 2)
            {
                
                destroytimer = false;
                countdown = 0;
                
                    Rpcgoodbye();
                
                
            }
        }
        
        
	}
   
   
    [ClientRpc]
    void Rpcgoodbye()
    {
        
            Debug.Log("destroying");
        
            
            Destroy(explosion);
            NetworkServer.Destroy(bomb);


    }
    //
    float dist;
    void CalculateExplosionValue(Vector3 aSource, Vector3 aTarget, float aRange)
    {
        dist = (aTarget - aSource).magnitude;
        if (dist > aRange)
        {
            dist = 0;
        }
        else {
            dist = 1.0f - dist / aRange;
        }
    }
    
    
    int damage;
    
void explode()
    {
        Vector3 bombposition = bomb.transform.position;

        
            
        Collider[] colliders = Physics.OverlapSphere(bombposition, radius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            Health health = hit.GetComponent<Health>();
            

            MyLobbyPlayer tm = hit.GetComponent<MyLobbyPlayer>();
            
            if (hit.GetComponent<sphereswitch>())
            {
                hit.GetComponent<sphereswitch>().changecolor = true;
            }

            
            //if (tm &&(tm == null || tm.TeamID==0  || throwerid==0 || tm.TeamID != throwerid))
            if(tm &&(tm.teamid != throwerid))
            {
                Debug.Log(tm.teamid);
                Debug.Log(throwerid);
                Debug.Log("first stage cleared");
               
                  
                    Debug.Log("it knows we have character movement and we are blueteam");
                    CalculateExplosionValue(bombposition, hit.transform.position, radius);
                    if (dist == 0)
                    {
                        damage = 0;
                    }
                    else
                    {
                        damage = (int)(power * 3 / (4 * 3.14 * dist * dist * dist));//calculation on unity answers for how add explosive force force is applied as distance increases https://answers.unity.com/questions/283146/how-to-calculate-force-from-explosion-on-a-rigidbo.html
                    }
                    Debug.Log(damage);
                    health.TakeDamage(damage);
                    rb.AddExplosionForce(power / 10, bombposition, radius, upforce * 0, ForceMode.Impulse);
                
               
            }
            

            if (rb != null && hit.CompareTag("Player")==false)
            {
                rb.AddExplosionForce(power, bombposition, radius, upforce, ForceMode.Impulse);
                
            }
        }
         
            Rpcexplosioneffect();
        Debug.Log("explosssiiionn!!!");
        destroytimer = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (hitsomething == false)
        {
            hitsomething = true;
            starttimer = true;
        }
        
    
    }


}
