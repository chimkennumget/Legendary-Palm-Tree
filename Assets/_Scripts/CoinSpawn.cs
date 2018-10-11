using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour {
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

	// Use this for initialization
	void Start () {
        // Coin Positions
        posArray[0] = new Vector3( 25, 1,  25);
        posArray[1] = new Vector3( 25, 1, -25);
        posArray[2] = new Vector3(-25, 1,  25);
        posArray[3] = new Vector3(-25, 1, -25);
        posArray[4] = new Vector3( 50, 1,  50);
        posArray[5] = new Vector3( 50, 1, -50);
        posArray[6] = new Vector3(-50, 1,  50);
        posArray[7] = new Vector3(-50, 1, -50);
        posArray[8] = new Vector3(  0, 1,  50);
        posArray[9] = new Vector3(  0, 1, -50);      

        // More than 10 iterations will cause an overflow
        for (int i = 0; i < 5; i++)
        {
            spawnLoc();
        }
    }

    private void spawnLoc() {
        int index = getNewN();
		GameObject bob = Instantiate(Coin, posArray[index], Quaternion.identity);
		bob.tag = "Coin";
        /*
        Instantiate(Coin, new Vector3(x, y, z), Quaternion.identity);
        If you want a specific position. for every new specific pos must -1
        from loop iterations in the start function. 
        */
    }

    // This method returns a number from 0 to 9 and when continuously
    // called, it will not repeat passed numbers. It has a maximum of
    // 10 calls until there is an overflow.
    private int getNewN()
    {
        System.Random rnd = new System.Random(); 
        int num = rnd.Next(0, 10);

        bool forcount = false; 

        // This loop goes through a List that is initally empty.
        // The random integer is checked to see if it is equivalent
        // with any of the integers in the List.
        // if it does find a 
        for (int y = 0; y < rep.Count; y++)
        {
            if (num == rep[y]) { forcount = true; }
        }

        if (forcount == true) { return getNewN(); }

        else
        {
            rep.Add(num);
            return num;
        }
    }
}
