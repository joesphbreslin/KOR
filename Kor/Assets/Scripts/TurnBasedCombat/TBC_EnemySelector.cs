using UnityEngine;
using System.Collections.Generic;
using System;
using Types;

public class TBC_EnemySelector : MonoBehaviour {

    [Serializable]
    public struct EnemySelection
    {
        public Area area;
        public Enemy[] enemies;
    }
    public EnemySelection[] enemyByArea;
    public Dictionary<Area, Enemy[]> enemyDictionary = new Dictionary<Area,Enemy[]>();

    private void Start()
    {
        for(int i = 0; i < enemyByArea.Length; i++)
        {
            enemyDictionary.Add(enemyByArea[i].area, enemyByArea[i].enemies);
        }
    }
}
