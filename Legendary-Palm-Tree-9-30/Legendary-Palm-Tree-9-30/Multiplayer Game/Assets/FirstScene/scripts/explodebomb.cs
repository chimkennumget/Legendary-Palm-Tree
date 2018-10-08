using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodebomb : MonoBehaviour {
    GameObject explosion;
    ParticleSystem parts;
    CharacterMovement cm;
    public GameObject psholder;
    public GameObject bomb;
    public float power=10;
    public float radius=5;
    public float upforce=1;
    public float countdown;
    public bool starttimer=false;
    bool destroytimer = false;
    float duration;
    
	// Use this for initialization
	void Start () {

        //this.GetComponent<Rigidbody>().isKinematic = true;
	}
    
    void explosioneffect()
    {
        explosion = Instantiate(psholder, bomb.transform.position, bomb.transform.rotation) as GameObject;
        parts = explosion.GetComponent<ParticleSystem>();
        duration = parts.main.duration;
        
        
        
       
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
            if (countdown > 1)
            {
                destroytimer = false;
                countdown = 0;
                goodbye();
                
            }
        }
        if(countdown > 3)
        {
            explode();
            starttimer = false;
            countdown = 0;
            
        }
        
	}
    
    void goodbye()
    {
        
            Debug.Log("destroying");
            Destroy(bomb);
            Destroy(explosion, duration);


    }
    


void explode()
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
        
        explosioneffect();
        destroytimer = true;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        starttimer = true;
        
    
    }


}
