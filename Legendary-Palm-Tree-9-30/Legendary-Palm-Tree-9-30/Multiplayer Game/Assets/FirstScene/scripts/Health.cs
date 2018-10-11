using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Health : NetworkBehaviour {
    public const int maxHealth = 100;
    public int healthbardoubler = 2;
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
    void adjusthealthbar(int health)
    {
        healthbar.sizeDelta = new Vector2(health * healthbardoubler, healthbar.sizeDelta.y);
    }
    [ClientRpc]
    void Rpcrespawn()
    {
        if (isLocalPlayer)
        {
            this.transform.position = this.GetComponent<CharacterMovement>().startingpoint;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
