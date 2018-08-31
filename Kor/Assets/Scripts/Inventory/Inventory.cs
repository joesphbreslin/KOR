using UnityEngine;
using System;

public class Inventory : MonoBehaviour {

    public static Inventory _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public Item[] items;   
}
