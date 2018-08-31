using UnityEngine;
using UnityEditor.Animations;
using System.Collections.Generic;
using Types;
public class TBC_Character : MonoBehaviour {

    public List<EElement> elementalResistance = new List<EElement>();
    public List<EElement> elementalWeakness = new List<EElement>();
    public EEffect currentEffect = 0;
    public ECharacterType characterType;
    public Animator animator;
    SpriteRenderer spriteRenderer;
    public Character character;
    public Vector2 returnPos;

    public float hitPoints;

    public float strength,
                    defence,
                    attack,
                    agility,
                    actionPoints;

    public Specials[] specials;

    //TODO EXPAND ON THIS FOR CHARACTER FUNCTIONALITY
    // Update is called once per frame
    public void TBC_InitialiseCharacter()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = character.animatorController;
        currentEffect = 0;
        this.gameObject.name = character.title;
        //Stats 
        characterType = character.characterType;
        hitPoints = character.hitPoints;
        strength = character.strength;
        attack = character.attack;
        agility = character.agility;
        actionPoints = character.actionPoints;
        specials = character.specials;

        foreach(EElement element in character.elementResistance)
        {
            elementalResistance.Add(element);
        }

        foreach (EElement element in character.elementWeakness)
        {
            elementalWeakness.Add(element);
        }

    }
}

