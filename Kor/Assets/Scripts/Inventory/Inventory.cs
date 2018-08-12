using UnityEngine;
using System;


public class Inventory : MonoBehaviour {

    public static Inventory _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    [Serializable]
    public struct _Item
    {
        public Item item;
        public int Amount;
    }

    public _Item[] items;
   
}
