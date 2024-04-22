using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public static int _numChests;

    void Start()
    {
        SetNumChests();
    }

    public int NumChests()
    {
        return _numChests;
    }

    private int SetNumChests()
    {
        _numChests = GameObject.FindGameObjectsWithTag("Chest").Length;
        return _numChests;
    }
}
