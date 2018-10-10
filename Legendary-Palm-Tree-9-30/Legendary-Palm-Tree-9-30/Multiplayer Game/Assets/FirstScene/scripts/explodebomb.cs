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
    
	// Use this for initialization
	void Start () {
        
        //this.GetComponent<Rigidbody>().isKinematic = true;
    }
    [ClientRpc]
    void Rpcexplosioneffect()
    {
        explosion = Instantiate(psholder, bomb.transform.position, bomb.transform.rotation) as GameObject;
    }

    // Update is called once per frame
    void LateUpdate () {
        
        
        if (starttimer)
        {
            if (delayexplode)
            {
                
                countdown += Time.deltaTime;
                
                if (countdown > 3)
                {
                    countdown = 0;
                    Rpcexplode();
                    delayexplode = false;
                    starttimer = false;
                }
            }
            else
            {
                Rpcexplode();
                starttimer = false;
                countdown = 0;
            }
            
            

        }
        if (destroytimer)
        {
            Debug.Log("destroytimer is on");
            countdown += Time.deltaTime;
            if (countdown > 2)
            {
                Debug.Log("goodbye");
                destroytimer = false;
                countdown = 0;
                Rpcgoodbye();
                
            }
        }
        
        
	}
    [ClientRpc]
    void Rpcdoom()
    {
        //Destroy(bomb);
        //Destroy(explosion);
    }
    [ClientRpc]
    void Rpcgoodbye()
    {
        
            Debug.Log("destroying");
        //NetworkIdentity.Destroy(bomb);
            
            Destroy(explosion);
            Destroy(bomb);


    }
    

[ClientRpc]
void Rpcexplode()
    {
        Vector3 bombposition = bomb.transform.position;

        
            
        Collider[] colliders = Physics.OverlapSphere(bombposition, radius);
        foreach(Collider hit in colliders)
        {
            if (hit.GetComponent<sphereswitch>())
            {
                hit.GetComponent<sphereswitch>().changecolor = true;
            }
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && hit.CompareTag("Player") == false)
            {
                rb.AddExplosionForce(power, bombposition, radius, upforce, ForceMode.Impulse);
                
            }
        }
        
        Rpcexplosioneffect();
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
