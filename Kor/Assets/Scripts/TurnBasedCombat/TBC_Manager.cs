using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class TBC_Manager : MonoBehaviour {

    public Area area; // this must be initialised to match global Area Value
    private float enemyCountSeed = 5.9f;

    public string[] partyMembers;

    TBC_AddEnemies tBC_AddEnemies;
    TBC_AddParty tBC_AddParty;
    TBC_AddPlayer tBC_AddPlayer;
    TBC_Queue tBC_Queue;
    TBC_UI tBC_UI;

    public int turnOrderIndex = 0;

    void Start () {
        tBC_AddEnemies = GetComponent<TBC_AddEnemies>();
        tBC_AddPlayer = GetComponent<TBC_AddPlayer>();
        tBC_AddParty = GetComponent<TBC_AddParty>();
        tBC_Queue = GetComponent<TBC_Queue>();
        tBC_UI = GetComponent<TBC_UI>();

        tBC_AddEnemies.Init(RandomEnemyCount(enemyCountSeed));
        tBC_AddPlayer.Init();
        tBC_AddParty.Init(partyMembers);

        tBC_Queue.PrintQueue();
        tBC_UI.UpdateUi();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
        

    /*
    * FUNCTIONS TODO
    * Add Enemies i.e count, position, stats etc                TBC_AddEnemies Entry Function();    [x]
    * Add Player and Party to positions, position, stats etc    TBC_AddParty Entry Function();      [x]
    * Animation to new scene                                    TBC_Camera Entry Function();        []
    * Determine turn order with multi-variable analysis         TBC_TurnOrder Start Function()      []
    * dialogue                                                  TBC_Actions                         []
    * begin queue                                               while() Queue TBC_TurnOrder         []                        
    * update camera target                                      TBC_Camera                          []
    * Enemy Attack/ Menu with actions for player                TBC_Actions                         []
    * Toggle targets                                            TBC_Actions, TBC_Camera
    * continue this until successful flee, death or victory     TBC_Manager
    * closing animation                                         TBC_Camera
    * rewards                                                   TBC_Manager
    * 
    */
    private int RandomEnemyCount(float countSeed)
    {
        return Mathf.FloorToInt(Random.Range(1f, countSeed));
    }
}
