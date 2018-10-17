using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Health : NetworkBehaviour {
    public const int maxHealth = 100;
    public int healthbardoubler = 2;
    [SyncVar]float regentimerwait=0;
    [SyncVar]float regentimer=0;
    bool regenerating = false;
    [SyncVar(hook = "resetwaittimer")]public bool gothit=false;
    [SyncVar(hook = "adjusthealthbar")]public int currentHealth = maxHealth;
    public RectTransform healthbar;
    
    public void TakeDamage(int amount, GameObject dealer) 
    {
        
        if (isServer)
        {



            currentHealth -= amount;
            gothit = true;
            Debug.Log(gothit + "i got hit, stop regenerating");
            regentimerwait = 0;
            if (currentHealth <= 0)
            {
                GetComponent<CharacterMovement>().deaths++;
                Debug.Log(GetComponent<CharacterMovement>().deaths);
                dealer.GetComponent<CharacterMovement>().kills++;
                Debug.Log(dealer.GetComponent<CharacterMovement>().kills);
                currentHealth = maxHealth;
                Rpcrespawn();
            }
        }
         else if(!isServer)
        {
            Cmdtakedamage(amount);
            Debug.Log("probably the host got hit");
        }
        
    }
    [Command]
    void Cmdtakedamage(int amount)
    {
        Rpctakedamage(amount);
        
    }
    [ClientRpc]
    void Rpctakedamage(int amount)
    {
        currentHealth -= amount;
        gothit = true;
        Debug.Log(gothit + "i got hit, stop regenerating");
        regentimerwait = 0;
        if (currentHealth <= 0)
        {
            currentHealth = maxHealth;
            Rpcrespawn();
        }
    }
    public void resetwaittimer(bool stopregen)
    {
        if (stopregen)
        {
            regentimerwait = 0;
        }
    }
  
    //[ClientRpc]
    [Command]
    void Cmdregen()
    {
        if ( currentHealth!=maxHealth)
        {
            if (regentimerwait < 5)
            {
                
                regentimerwait += Time.deltaTime;
            }
            else if (regentimerwait >= 5)
            {
                //Debug.Log("it thinks it is greater");
                regentimerwait = 5;
                regenerating = true;
            }
            if (regenerating==true)
            {
                regentimer += Time.deltaTime;
            }
            if (regentimer >= .1f)
            {
                Debug.Log(regentimerwait);
                this.currentHealth += 1;
                regentimer = 0;
            }
        }
        if( currentHealth >= maxHealth || gothit )
        {
            gothit = false;
            regenerating = false;
            regentimerwait = 0;

        }
    }
    
    void adjusthealthbar(int health)
    {
        
            healthbar.sizeDelta = new Vector2(health * healthbardoubler, healthbar.sizeDelta.y);
        
    }
    [ClientRpc]
    void Rpcrespawn()
    {
        if (isLocalPlayer)
        {
            this.GetComponent<Rigidbody>().angularVelocity = this.GetComponent<Rigidbody>().angularVelocity * .01f;
            this.transform.position = this.GetComponent<CharacterMovement>().startingpoint;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isLocalPlayer)
        {
            Cmdregen();
        }
        
	}
}
