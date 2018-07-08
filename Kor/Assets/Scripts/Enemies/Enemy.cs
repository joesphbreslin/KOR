/* Joey Breslin 08/07/2018
 * Enemy Object Used as bolier plate for enemy creation  */

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class Enemy : ScriptableObject
{
    //TODO Move types to generic Type Namespace
    public enum E_EnemyType { FIRE, WATER, CYBER, ROBOTIC, ICE, EARTH, POISON };
    public enum E_ActionKey { IDLE, ATTACK_A, ATTACK_B, ATTACK_C, DEATH, DAMAGED };
    public enum E_DialogueKey { DEFEATED, VICTORIOUS, WINNING, LOSING, SUPRISE, RANSOM };

    public Dictionary<E_ActionKey, ActionStruct> actions;
    public Dictionary<E_DialogueKey, String> dialogue;

    [Space(10)]
    public string enemyTitle;

    [Space(10)]
    public E_EnemyType enemyType;

    [Space(10)]
    public Sprite enemyMenuSprite;

    #region Actions Dictionary
    //NOTE Animations must be added to animations Dictionary, call Update Animations from controlling script  
    [Serializable]
    public struct ActionStruct
    {
        [Tooltip("Key used for Action dictionary, DO NOT duplicate keys")]
        public E_ActionKey eActionKey;

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
        public E_DialogueKey eDialogueKey;
        [TextArea]
        public String dialogueText;
    }

    [Header("Dialogue Turn Based Combat")]
    public DialogueStruct[] dialogueStructs;
    #endregion


    [Header("Stats")]
    public float hitPoints;

    public float    strength,
                    defence,
                    attack,
                    agility,
                    stamina;

    [Header("Rewards")]
    public int xpReward;

    public int currencyReward;
    public string[] rewardDrops;

    [HideInInspector]
    public Vector2 enemyPosition;

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

