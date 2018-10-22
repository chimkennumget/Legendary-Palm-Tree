using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnMountain : MonoBehaviour
{
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

    // Use this for initialization
    void Start()
    {
        // Coin Positions
        posArray[0] = new Vector3(169.1847f, 180.4926f, 121.1793f);
        posArray[1] = new Vector3(137.309f, 119.7101f, 91.32647f);
        posArray[2] = new Vector3(170.6202f, 119.7101f, 141.1429f);
        posArray[3] = new Vector3(167.7393f, 64.83302f, 127.0879f);
        posArray[4] = new Vector3(172.1113f, 170.0359f, 139.551f);
        posArray[5] = new Vector3(152.5421f, 85.42009f, 29.55234f);
        posArray[6] = new Vector3(154.8227f, 121.6905f, 117.7209f);
        posArray[7] = new Vector3(156.5943f, 138.4375f, 108.3116f);
        posArray[8] = new Vector3(165.6284f, 174.9135f, 68.74926f);
        posArray[9] = new Vector3(171.3707f, 67.31259f, 136.383f);

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