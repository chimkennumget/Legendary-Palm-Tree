using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnAmbersRoom : MonoBehaviour
{
    public GameObject Coin;
    List<int> rep = new List<int>();
    Vector3[] posArray = new Vector3[10];

    // Use this for initialization
    void Start()
    {
        // Coin Positions
        posArray[0] = new Vector3(-158.8062f, 197.4109f, 92.52145f);
        posArray[1] = new Vector3(-131.0213f, 183.6096f, 143.4845f);
        posArray[2] = new Vector3(-162.127f, 45.4817f, -5.277756f);
        posArray[3] = new Vector3(-111.7782f, 77.59511f, 123.3584f);
        posArray[4] = new Vector3(-109.8683f, 193.6582f, 5.567459f);
        posArray[5] = new Vector3(-115.3197f, 105.2936f, 1.843628f);
        posArray[6] = new Vector3(-114.6862f, 149.8838f, 78.02912f);
        posArray[7] = new Vector3(-108.7742f, 57.45946f, -6.256714f);
        posArray[8] = new Vector3(-113.0162f, 51.14426f, 73.57585f);
        posArray[9] = new Vector3(-112.1237f, 176.7953f, -6.851776f);

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
