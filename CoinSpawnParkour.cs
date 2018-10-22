using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnParkour : MonoBehaviour
{
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

    // Use this for initialization
    void Start()
    {
        // Coin Positions
        posArray[0] = new Vector3(81.54944f, 75.78873f, 332.6135f);
        posArray[1] = new Vector3(77.93848f, 36.41949f, 336.9388f);
        posArray[2] = new Vector3(81.36499f, 57.5325f, 325.2708f);
        posArray[3] = new Vector3(94.35718f, 32.58371f, 347.75f);
        posArray[4] = new Vector3(113.512f, 38.0325f, 349.5534f);
        posArray[5] = new Vector3(91.92566f, 39.62137f, 350.4525f);
        posArray[6] = new Vector3(114.1379f, 32.9769f, 338.2708f);
        posArray[7] = new Vector3(87.4801f, 33.45834f, 323.9066f);
        posArray[8] = new Vector3(111.8993f, 36.25903f, 323.9066f);
        posArray[9] = new Vector3(81.36499f, 82.24857f, 319.1319f);

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

    private void spawnLoc()
    {
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

