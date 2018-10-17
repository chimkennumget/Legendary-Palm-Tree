using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnMaze : MonoBehaviour {
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

	// Use this for initialization
	void Start () {
        // Coin Positions
        posArray[0] = new Vector3(-20.45f, 0.2999992f, 70.8f);
        posArray[1] = new Vector3(119.55f, 0.2999992f, 16.3f);
        posArray[2] = new Vector3(65.05f, 0.2999992f, 140.3f);
        posArray[3] = new Vector3(130.55f, 0.2999992f, 90.3f);
        posArray[4] = new Vector3(40.3f, 0.2999992f, 14.04999f);
        posArray[5] = new Vector3(120.3f, 0.2999992f, 32.8f);
        posArray[6] = new Vector3(10.55f, 0.2999992f, 61.55f);
        posArray[7] = new Vector3(-10.95002f, 0.2999992f, 125.8f);
        posArray[8] = new Vector3(56.3f, 0.2999992f, 101.3f);
        posArray[9] = new Vector3(96.3f, 0.2999992f, 46.8f);      

        // More than 10 iterations will cause an overflow
        for (int i = 0; i < 5; i++)
        {
            spawnLoc();
        }
    }
    private void Update()
    {
        transform.Rotate(0, 2, 0, Space.Self);
    }

    private void spawnLoc() {
        int index = getNewN();
		GameObject bob = Instantiate(Coin, posArray[index], Quaternion.identity);
		bob.tag = "Coin";
        bob.transform.Rotate(90, 0, 0);
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
