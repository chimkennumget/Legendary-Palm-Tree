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
    public float countdown;
    public bool starttimer=false;
    bool destroytimer = false;
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
        //parts = explosion.GetComponent<ParticleSystem>();
        //duration = parts.main.duration;
        

        



    }

    // Update is called once per frame
    void Update () {
        
        
        if (starttimer)
        {
            countdown += Time.deltaTime;
        }
        if(destroytimer)
        {
            countdown += Time.deltaTime;
            if (countdown > 2)
            {
                destroytimer = false;
                countdown = 0;
                Rpcgoodbye();
                
            }
        }
        if(countdown > 3)
        {
            Rpcexplode();
            starttimer = false;
            countdown = 0;
            
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
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if(rb!= null)
            {
                rb.AddExplosionForce(power, bombposition, radius, upforce, ForceMode.Impulse);
                
            }
        }
        
        Rpcexplosioneffect();
        destroytimer = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        starttimer = true;
        
    
    }


}
