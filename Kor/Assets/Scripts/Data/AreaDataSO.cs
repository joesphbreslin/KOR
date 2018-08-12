using System.Collections.Generic;
using System;
using UnityEngine;
using Types;

[CreateAssetMenu(fileName = "ONLY ONCE", menuName = "Area Information")]
public class AreaDataSO : ScriptableObject {

    public Dictionary<EArea, AreaStruct> areaDictionary = new Dictionary<EArea, AreaStruct>();

    public string enemyOBJPath;
    [Serializable]
    public struct AreaStruct
    {
        public EArea area;
        public Character[] enemyCharacters;
        public Character[] npcCharacters;
    }

    public AreaStruct[] areaStructs;

    public Character ReturnEnemy(EArea areaKey)
    {
        for (int i = 0; i < areaStructs.Length; i++)
        {         
            areaDictionary.Add(areaStructs[i].area, areaStructs[i]);
        }

        int enemyArrLength = areaDictionary[areaKey].enemyCharacters.Length;
        enemyArrLength = UnityEngine.Random.Range(0, enemyArrLength);
        Character enemy = areaDictionary[areaKey].enemyCharacters[Mathf.RoundToInt(enemyArrLength)];
        areaDictionary.Clear();
        return enemy;      
    }
}
