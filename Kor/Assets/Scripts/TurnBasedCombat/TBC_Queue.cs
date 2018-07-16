using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBC_Queue : MonoBehaviour {

    public List<GameObject> turnOrder = new List<GameObject>();

    public void PrintQueue()
    {
        
            Debug.Log(turnOrder.Count);
        
    }
    public void AddTurnOrder(GameObject g)
    {
        turnOrder.Add(g);
    }

    public void RemoveTurnOrder(GameObject g)
    {
        turnOrder.Remove(g);
    }

}
