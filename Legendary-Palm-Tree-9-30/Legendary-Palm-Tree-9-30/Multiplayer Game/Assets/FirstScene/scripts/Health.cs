using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Health : NetworkBehaviour {
    public const int maxHealth = 100;
    public int healthbardoubler = 2;
    float regentimerwait=0;
    float regentimer=0;
    bool regenerating = false;
    [SyncVar(hook = "adjusthealthbar")]public int currentHealth = maxHealth;
    public RectTransform healthbar;
    public void TakeDamage(int amount) 
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0){
            currentHealth = maxHealth;
            Rpcrespawn();
        }
        
    }
  
    [Command]
    void Cmdregen()
    {
        if (isLocalPlayer && currentHealth!=maxHealth)
        {
            if (regentimerwait < 5)
            {
                
                regentimerwait += Time.deltaTime;
            }
            else if (regentimerwait >= 5)
            {
                Debug.Log("it thinks it is greater");
                regentimerwait = 5;
                regenerating = true;
            }
            if (regenerating==true)
            {
                regentimer += Time.deltaTime;
            }
            if (regentimer >= .1f)
            {
                this.currentHealth += 1;
                regentimer = 0;
            }
        }
        else if(isLocalPlayer && currentHealth >= maxHealth)
        {
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
        
        Cmdregen();
	}
}
