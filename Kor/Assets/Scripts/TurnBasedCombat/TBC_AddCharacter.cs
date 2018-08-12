using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class TBC_AddCharacter : MonoBehaviour {

    Character[] characters;

    public Character playerCharacter;
    public Vector2 playerPosition;

    public Vector2[] enemyPositions;

    public Character[] partyCharacters;
    public Vector2[] partyPositions;
    public int maxEnemies = 6;

    public AreaDataSO areaData;

    //TODO GetParty from manager settings

    public void Init()
    {
        AddPlayer();
        AddParty();
        AddEnemies(RandomEnemyCount(maxEnemies),Manager.area);
    }

    void AddPlayer()
    {
        GameObject playerOBJ = Instantiate(Resources.Load("Characters\\TBC_Character"), this.transform) as GameObject;
        playerOBJ.transform.position = playerPosition;
        playerOBJ.GetComponent<TBC_Character>().returnPos = playerPosition;
        playerOBJ.GetComponent<TBC_Character>().character = playerCharacter;
        playerOBJ.GetComponent<TBC_Character>().TBC_InitialiseCharacter();
    }

    void AddParty()
    {
        for(int i = 0; i < partyCharacters.Length; i++)
        {
            GameObject partyMember = Instantiate(Resources.Load("Characters\\TBC_Character"), this.transform) as GameObject;
            partyMember.transform.position = partyPositions[i];
            partyMember.GetComponent<TBC_Character>().returnPos = partyPositions[i];
            partyMember.GetComponent<TBC_Character>().character = partyCharacters[i];
            partyMember.GetComponent<TBC_Character>().TBC_InitialiseCharacter();
        }
    }

    void AddEnemies(int enemyAmount, EArea area)
    {
        for(int i = 0; i < enemyAmount; i++)
        {
            GameObject enemy = Instantiate(Resources.Load("Characters\\TBC_Character"), this.transform) as GameObject;
            enemy.transform.position = enemyPositions[i];
            enemy.GetComponent<TBC_Character>().returnPos = enemyPositions[i]; ;
            enemy.GetComponent<TBC_Character>().character = areaData.ReturnEnemy(area);
            enemy.GetComponent<TBC_Character>().TBC_InitialiseCharacter();
        }
    }

    private int RandomEnemyCount(int countSeed)
    {
        return Mathf.RoundToInt(Random.Range(1f, countSeed));
    }




}
