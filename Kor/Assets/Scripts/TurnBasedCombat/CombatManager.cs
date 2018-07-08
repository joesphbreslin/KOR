/* Joey Breslin 07/07/2018
 * Turn Based Combat System */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {
    
    private int enemyLocationCount = 6;
    private Vector2[] enemyLocations;

    public float enemyCountSeed = 5.9f;                     //TEMPORARY Declaration, will call from level management script in future
    List<Enemy> enemies = new List<Enemy>();

    private void Start()
    {
        enemyLocations = new Vector2[enemyLocationCount];
        AddEnemyLocations();
        AssignEnemiesToLocations(enemies,enemyLocations, EnemyCount(enemyCountSeed));
    }

    //used to add values to vector2 array, must be implemented in Start()
    private void AddEnemyLocations()
    {
        float x = 0, y = 0;
        for(int i = 0; i < enemyLocationCount; i++)
        {
            switch (i)
            {
                case 1:
                    x = -1; y = -1;
                    break;
                case 2:
                    x = 1; y = -1;
                    break;
                case 3:
                    x = -2; y = -2;
                    break;
                case 4:
                    x = 0; y = -2;
                    break;
                case 5:
                    x = 2; y = -2;
                    break;
                default:
                    x = 0; y = 0;
                    break;
            }
            enemyLocations[i] = new Vector2(x, y);
        }       
    }

    //TEMPORARY Solution for determining size of enemy party //TODO Add input into function from environment i.e. level progression.
    private int EnemyCount(float countSeed)
    {
        return Mathf.FloorToInt(Random.Range(1f, countSeed));
    }

    private void AssignEnemiesToLocations(List<Enemy> _enemies ,Vector2[] _enemyLocations, int _enemyCount)
    {
        AddEnemyToList(_enemies, _enemyCount);
        switch (_enemyCount)
        {
            case 2:
                // add 2 enemies, position 1 and 2               
                _enemies[0].EnemyTransform.position = new Vector3(_enemyLocations[1].x, 0, _enemyLocations[1].y);
                _enemies[1].EnemyTransform.position = new Vector3(_enemyLocations[2].x, 0, _enemyLocations[2].y);
                break;
            case 3:
                // add 3 enemies, position 0, 1 and 2
                _enemies[0].EnemyTransform.position = new Vector3(_enemyLocations[0].x, 0, _enemyLocations[0].y);
                _enemies[1].EnemyTransform.position = new Vector3(_enemyLocations[1].x, 0, _enemyLocations[1].y);
                _enemies[2].EnemyTransform.position = new Vector3(_enemyLocations[2].x, 0, _enemyLocations[2].y);
                break;
            case 4:
                // add 4 enemies, position 1, 2,3 and 5 
                _enemies[0].EnemyTransform.position = new Vector3(_enemyLocations[1].x, 0, _enemyLocations[1].y);
                _enemies[1].EnemyTransform.position = new Vector3(_enemyLocations[2].x, 0, _enemyLocations[2].y);
                _enemies[2].EnemyTransform.position = new Vector3(_enemyLocations[3].x, 0, _enemyLocations[3].y);
                _enemies[3].EnemyTransform.position = new Vector3(_enemyLocations[5].x, 0, _enemyLocations[5].y);
                break;
            case 5:
                // add 5 enemies, position 1, 2, 3, 4 and 5 
                _enemies[0].EnemyTransform.position = new Vector3(_enemyLocations[1].x, 0, _enemyLocations[1].y);
                _enemies[1].EnemyTransform.position = new Vector3(_enemyLocations[2].x, 0, _enemyLocations[2].y);
                _enemies[2].EnemyTransform.position = new Vector3(_enemyLocations[3].x, 0, _enemyLocations[3].y);
                _enemies[3].EnemyTransform.position = new Vector3(_enemyLocations[4].x, 0, _enemyLocations[4].y);
                _enemies[4].EnemyTransform.position = new Vector3(_enemyLocations[5].x, 0, _enemyLocations[5].y);
                break;
            default:
                // Add 1 enemy to position 0
                _enemies[0].EnemyTransform.position = new Vector3(_enemyLocations[0].x, 0, _enemyLocations[0].y);
                break;
        }

        foreach (Enemy e in enemies) {
            Debug.Log(e.title + " " + e.EnemyTransform.position);
        }
    }

    void AddEnemyToList(List<Enemy> _enemies, int _enemyCount)
    {
        for(int i = 0; i < _enemyCount; i++)
        {
            Enemy enemy = Resources.Load("Enemies\\Angry Phil") as Enemy;
            enemy.EnemyTransform = GetComponent<Transform>();
            _enemies.Add(Resources.Load("Enemies\\Angry Phil") as Enemy);
        }
    }

    //private void UpdateEnemyList(List<Vector2> enemyPositions, int enemyCount)
    //{
    //    for(int i = 0; i < enemyCount; i++)
    //    {
    //        enem
    //    }
    //}

    /*
     * FUNCTIONS TODO
     * Add enemy count
     * Add Player and Party to positions
     * Add Enemies to position
     * Animation to new scene
     * Determine turn order with multi-variable analysis
     * dialogue 
     * begin queue
     * update camera target 
     * Enemy Attack/ Menu with actions for player
     * Toggle targets
     * continue this until successful flee, death or victory
     * closing animation
     * rewards
     * 
     */
}
