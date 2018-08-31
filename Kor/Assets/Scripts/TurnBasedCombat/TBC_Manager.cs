using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class TBC_Manager : MonoBehaviour {

    public EArea area; // this must be initialised to match global Area Value
    public Character[] partyMembers;
    TBC_AddCharacter addCharacters;
    TBC_Order tBC_Order;
    TBC_UI tBC_UI;
    TBC_MenuLogic tBC_MenuLogic;
    public Vector2 onGuiLocation;
    public int turnOrderIndex;

    void Start () {

        #region GetTBCComponents
        addCharacters = GetComponent<TBC_AddCharacter>();
        tBC_Order = GetComponent<TBC_Order>();
        tBC_UI = GetComponent<TBC_UI>();
        tBC_MenuLogic = GetComponent<TBC_MenuLogic>();
        #endregion

        turnOrderIndex = 0;         //starts turn order 
        addCharacters.Init();       //AddAllCharacters
        tBC_Order.PopulateList();   //AddAllCharacters to Core List
        
        tBC_UI.UpdateUi();
        tBC_MenuLogic.Menu();

    }

    public IEnumerator NextPlayer(float time)
    {
        yield return new WaitForSeconds(time);

        if (turnOrderIndex != tBC_Order.lCharacters.Count - 1)
        {
            turnOrderIndex++;
        }
        else
        {
            turnOrderIndex = 0;
        }

        tBC_UI.UpdateUi();
    }

    /// <summary>
    ////DEBUG
    /// </summary>

    private void OnGUI()
    {
        TBC_Character currentCharacter = tBC_Order.lCharacters[turnOrderIndex].GetComponent<TBC_Character>();
        GUI.Label(new Rect(onGuiLocation.x, onGuiLocation.y, 200, 120), "HP:\t " + currentCharacter.hitPoints +
                                            "\nSTR:\t" + currentCharacter.strength +
                                            "\nATK:\t" + currentCharacter.attack +
                                            "\nDEF:\t" + currentCharacter.defence +
                                            "\nAGL:\t" + currentCharacter.agility +
                                            "\nAP:\t" + currentCharacter.actionPoints +
                                            "\nEffector:\t" + currentCharacter.currentEffect.ToString(), "box");
    }

    /*
     *  Menu pop up every turn
     *  Menu includes Limit option if special Bar is full 
     *  Menu includes sub menu options for Attack, Skill, Special, Defend, maybe magic
     *  Menu also contains Item and equipment changing
     *  Menu Also Contains party swaping
     *  MENU //Menu Navigation keys (TEMP) left, right, up, down arrows
     *  
     *      PAGE_1     
     *          -ATTACK
     *              CHOOSE TARGET
     *                  ACTION
     *                      [Next]
     *             
     *          -DEFEND
     *              [Next]
     *          -SPECIAL**          
     *          -SKILL  **
     *          -MAGIC  **
     *            *-> [LIST]
    *                  CHOOSE TARGET
    *                        ACTION
    *                           [Next]
     *          
     *      PAGE_2
     *          -ITEM
     *              [List]
     *                  Choose Target
     *                              [Next]
     *                     
     *          -EQIPMENT
     *               [List]
     *                  ChooseTarget
     *                          [Next]
     *                     
     *          -SWAPPLAYER
     *              [List]
     *                  Select
     *                      [Next]
     *          
     * 
     */



    void Update () {
		
	}
        

    /*
    * FUNCTIONS TODO
    * Add Enemies i.e count, position, stats etc                TBC_AddEnemies Entry Function();    [x]
    * Add Player and Party to positions, position, stats etc    TBC_AddParty Entry Function();      [x]
    * Animation to new scene                                    TBC_Camera Entry Function();        []
    * Determine turn order with multi-variable analysis         TBC_TurnOrder Start Function()      [X]
    * dialogue                                                  TBC_Actions                         []
    * begin queue                                               while() Queue TBC_TurnOrder         []                        
    * update camera target                                      TBC_Camera                          []
    * Enemy Attack/ Menu with actions for player                TBC_Actions                         []
    * Toggle targets                                            TBC_Actions, TBC_Camera
    * continue this until successful flee, death or victory     TBC_Manager
    * closing animation                                         TBC_Camera
    * rewards                                                   TBC_Manager
    * Make sure Attack is delayed until coroutine is finished maybe flag?
    */
  
}
