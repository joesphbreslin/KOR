using UnityEngine;
using UnityEditor.Animations;
using Types;
public class TBC_Character : MonoBehaviour {

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
                    stamina;

    public Specials[] specials;

    //TODO EXPAND ON THIS FOR CHARACTER FUNCTIONALITY
    // Update is called once per frame
    public void TBC_InitialiseCharacter()
    {
        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = character.animatorController;

        this.gameObject.name = character.title;
        //Stats 
        characterType = character.characterType;
        hitPoints = character.hitPoints;
        strength = character.strength;
        attack = character.attack;
        agility = character.agility;
        stamina = character.stamina;
        specials = character.specials;
       
    }
}

