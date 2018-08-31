/* Joey Breslin 31/07/2018
 * Character Object Used as bolier plate for enemy creation  */

using System;
using System.Collections.Generic;
using UnityEngine;
using Types;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]

public class Character : ScriptableObject
{
    public Dictionary<EActionKey, ActionStruct> actions;
    public Dictionary<EDialogueKey, String> dialogue;

    [Space(10)]
    public string title;

    [Space(10)]
    public ECharacterType characterType;

    [Space(10)]
    public ECharacterElement characterElement;

    [Space(10)]
    public Sprite menuSprite;

    #region Actions Dictionary
    //NOTE Animations must be added to animations Dictionary, call Update Animations from controlling script  
    [Serializable]
    public struct ActionStruct
    {
        [Tooltip("Key used for Action dictionary, DO NOT duplicate keys")]
        public EActionKey eActionKey;

        [Tooltip("Accompaning text to inform UI of Enemy states")]
        public string actionText;

        [Tooltip("Animation clip for action")]
        public AnimationClip animationClip;

        [Tooltip("Particle system for different states")]
        public GameObject particleSystem;
    }

    [Header("All Actions must be filled i.e IDLE, ATTACK_A etc..")]
    public ActionStruct[] actionStructs;
    #endregion

    #region Dialogue Dictionary
    [Serializable]
    public struct DialogueStruct
    {
        public EDialogueKey eDialogueKey;
        [TextArea]
        public String dialogueText;
    }

    [Header("Dialogue Turn Based Combat")]
    public DialogueStruct[] dialogueStructs;
    #endregion


    [Header("Stats")]
    public float hitPoints;

    public float strength,
                    defence,
                    attack,
                    agility,
                    stamina,
                    xp;

    public EEffect[] effectResistance;
    public EElement[] elementResistance;
    public EElement[] elementWeakness;
        
    [Header("Rewards")]
    public int xpReward;

    public int currencyReward;
    public string[] rewardDrops;

    public Specials[] specials;

    [HideInInspector]
    public Vector2 enemyPosition;

    public AnimatorController animatorController;

    #region Functions
    public void UpdateAnimations()
    {
        //May have to do this in combatmanager or enemies script
        for (int i = 0; i < actionStructs.Length; i++)
        {
            actions.Add(actionStructs[i].eActionKey, actionStructs[i]);
        }
    }

    void UpdateDialogue()
    {
        //May have to do this in combatmanager or enemies script
        for (int i = 0; i < dialogueStructs.Length; i++)
        {
            dialogue.Add(dialogueStructs[i].eDialogueKey, dialogueStructs[i].dialogueText);
        }
    }

    private void Awake()
    {
        if (callAwakeMethods)
        {
            UpdateAnimations();
            UpdateDialogue();
        }
    }
    #endregion

    [Header("Use to assign Dictionarys, TRUE if pre-made, FALSE if new Enemy is called from script")]
    public bool callAwakeMethods = false;

}

