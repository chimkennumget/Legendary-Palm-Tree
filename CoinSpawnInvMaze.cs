using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnInvMaze : MonoBehaviour
{
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

    // Use this for initialization
    void Start()
    {
        // Coin Positions
        posArray[0] = new Vector3(105.403f, 235.7889f, 10.91193f);
        posArray[1] = new Vector3(78.40842f, 235.7889f, 37.90652f);
        posArray[2] = new Vector3(46.01486f, 235.7889f, 5.513f);
        posArray[3] = new Vector3(-18.77225f, 235.7889f, 5.513f);
        posArray[4] = new Vector3(105.403f, 235.7889f, 83.79736f);
        posArray[5] = new Vector3(102.7036f, 235.7889f, 126.9887f);
        posArray[6] = new Vector3(48.71432f, 235.7889f, 86.49683f);
        posArray[7] = new Vector3(51.41379f, 235.7889f, 135.0871f);
        posArray[8] = new Vector3(24.41916f, 235.7889f, 118.8904f);
        posArray[9] = new Vector3(-10.67386f, 235.7889f, 121.5898f);

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

