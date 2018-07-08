using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class TBC_AddEnemies : MonoBehaviour {

    TBC_EnemySelector tBC_EnemySelector;
    TBC_Manager tBC_Manager;
    private int enemyLocationCount = 6;
    private int enemyCount;
    private Vector2[] enemyLocations;

    public List<GameObject> enemies = new List<GameObject>();

    public void Init(int _enemyCount)
    {
        tBC_EnemySelector = GetComponent<TBC_EnemySelector>();
        tBC_Manager = GetComponent<TBC_Manager>();
        enemyCount = _enemyCount;        //Add RandomCount    
        enemyLocations = new Vector2[enemyLocationCount];
        AddEnemyLocations();
        AddEnemyToList(enemies, enemyCount,tBC_Manager.area);
        AssignEnemiesToLocations(enemies, enemyLocations, enemyCount);
    }

    #region Safe
    private void AddEnemyLocations()
    {
        Vector2 location;
        for (int i = 0; i < enemyLocationCount; i++)
        {
            switch (i)
            {
                case 1:
                    location = new Vector3(-1, -1);
                    break;
                case 2:
                    location = new Vector3(1, -1);
                    break;
                case 3:
                    location = new Vector3(-2, -2);
                    break;
                case 4:
                    location = new Vector3(0, -2);
                    break;
                case 5:
                    location = new Vector3(2, -2);
                    break;
                default:
                    location = new Vector3(0, 0);
                    break;
            }
            enemyLocations[i] = location;
            Debug.Log(enemyLocations[i]);
        }
    }
    void AddEnemyToList(List<GameObject> _enemies, int _enemyCount, Area area)
    {
        for (int i = 0; i < _enemyCount; i++)
        {
            GameObject enemyOBJ = Instantiate(Resources.Load("Enemies\\EnemyObj")) as GameObject;
            Debug.Log(enemyOBJ.name);
            TBC_Enemy tBC_enemy = enemyOBJ.GetComponent<TBC_Enemy>();
            int randomIndex = (int)Random.Range(0, tBC_EnemySelector.enemyDictionary[area].Length);
            tBC_enemy.enemy = tBC_EnemySelector.enemyDictionary[area][randomIndex];
            //enemyOBJ.name = tBC_enemy.enemy.enemyTitle;
            tBC_enemy.TBC_Enemy_Init();
            _enemies.Add(enemyOBJ);
        }
    }
    private void AssignEnemiesToLocations(List<GameObject> _enemies, Vector2[] _enemyLocations, int _enemyCount)
    {
        switch (_enemyCount)
        {
            case 2:
                // add 2 enemies, position 1 and 2               
                _enemies[0].transform.position = _enemyLocations[1];
                _enemies[1].transform.position = _enemyLocations[2];
                break;
            case 3:
                // add 3 enemies, position 0, 1 and 2
                _enemies[0].transform.position = _enemyLocations[0];
                _enemies[1].transform.position = _enemyLocations[1];
                _enemies[2].transform.position = _enemyLocations[2];
                break;
            case 4:
                // add 4 enemies, position 1, 2,3 and 5 
                _enemies[0].transform.position = _enemyLocations[1];
                _enemies[1].transform.position = _enemyLocations[2];
                _enemies[2].transform.position = _enemyLocations[3];
                _enemies[3].transform.position = _enemyLocations[5];
                break;
            case 5:
                // add 5 enemies, position 1, 2, 3, 4 and 5 
                _enemies[0].transform.position = _enemyLocations[1];
                _enemies[1].transform.position = _enemyLocations[2];
                _enemies[2].transform.position = _enemyLocations[3];
                _enemies[3].transform.position = _enemyLocations[4];
                _enemies[4].transform.position = _enemyLocations[5];
                break;
            default:
                // Add 1 enemy to position 0
                _enemies[0].transform.position = _enemyLocations[0];
                break;
        }
    } 
    #endregion
}
