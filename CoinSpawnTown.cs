using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnTown : MonoBehaviour {

    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

    // Use this for initialization
    void Start()
    {
        // Coin Positions
        posArray[0] = new Vector3(48.00538f, 112.2092f, -25.16385f);
        posArray[1] = new Vector3(-18.71962f, 186.9355f, -50.32719f);
        posArray[2] = new Vector3(14.76364f, 165.6498f, -15.78854f);
        posArray[3] = new Vector3(116.0815f, 185.2824f, -46.1634f);
        posArray[4] = new Vector3(115.221f, 47.08418f, -47.18406f);
        posArray[5] = new Vector3(-13.12651f, 50.69218f, -49.76724f);
        posArray[6] = new Vector3(36.90215f, 52.27728f, -50.2911f);
        posArray[7] = new Vector3(74.28024f, 107.9823f, -44.25766f);
        posArray[8] = new Vector3(-1.585495f, 108.6616f, -49.76722f);
        posArray[9] = new Vector3(38.10985f, 184.4748f, -44.99827f);

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
