using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class TBC_Specials : MonoBehaviour {

    void Special(GameObject _attacker, GameObject _reciever, Specials _special)
    {
        switch (_special.specialType)
        {
            case ESpecialType.ATTACK:
                Attack(_attacker, _reciever, _special);      //I.E. Bomb / Magic type
                break;
            case ESpecialType.RECOVER:                  //I.E Recovery type
                Recover(_attacker, _reciever, _special);
                break;
            default:
                break;
        }
    }



    //Deliver Damageorhealth
    //Player particle effect
  
    
    void Attack(GameObject _attacker, GameObject _reciever, Specials _special)
    {
        float damage = 0;
        if (!IsImmune(_special.element, _reciever))
        {
            if (_reciever.GetComponent<TBC_Character>().elementalWeakness.Contains(_special.element)) {
                //DoubleDamage
                damage = Damage(2f, .5f, _attacker, _reciever, _special);
                //Add Effect
                if (_special.element > 0)
                {
                    int effectIndex = (int)_special.element;
                    _reciever.GetComponent<TBC_Character>().currentEffect = (EEffect)effectIndex; 
                }
            } else
            {
                //RegularDamage
                damage = Damage(1f, .5f, _attacker, _reciever, _special);
            }
        }
        else
        {
            //HalfDamage
            damage = Damage(.5f, .5f, _attacker, _reciever, _special);           
        }
        //Add Damage
        _reciever.GetComponent<TBC_Character>().hitPoints -= damage;
        //Play Particle Effect
        PlayParticleEffect(_reciever, _special, .5f);
    }


    void Recover(GameObject _attacker, GameObject _reciever, Specials _special)
    {

    }

    bool IsImmune(EElement element, GameObject _reciever)
    {
        TBC_Character tBC_Character = _reciever.GetComponent<TBC_Character>();

        if (tBC_Character.elementalResistance.Contains(element))
            return true;
        else
            return false;
    }

    #region ParticleEffect
    void PlayParticleEffect(GameObject _reciever, Specials _special,float _yMod)
    {
        GameObject g = Instantiate(_special.particleSystem, transform, false) as GameObject;
        g.transform.position = new Vector3(_reciever.transform.position.x, _reciever.transform.position.y + _yMod, _reciever.transform.position.z);
    }

    #region Damage
    // Damage() retuns a damage value for use with special moves| 
    // Algorithm: mult = Ran(mult - attackRange, mult + attackRange); 
    // return _attacker.tbc_character.attack + SpecialModifier - reciever.TBC_Character.defence * mult;
    float Damage(float _damageMult,float damageRange, GameObject _attacker, GameObject _reciever, Specials _special)
    {
        TBC_Character attackingCharacter = _attacker.GetComponent<TBC_Character>();
        TBC_Character recivingCharacter = _reciever.GetComponent<TBC_Character>();

        float mult = Random.Range(_damageMult - damageRange, _damageMult + damageRange);
        return (attackingCharacter.attack + _special.specialMod - recivingCharacter.defence) * mult;
    }
    #endregion














    //public enum EElement { FIRE, WATER, CYBER, ROBOTIC, ICE, EARTH, POISON };
    /*
    public string specialName;
    public EElement element;
    public ESpecialType specialType;

    public float attackMod;
    public float recoverMod;

    public GameObject particleSystem;



    GameObject g = Instantiate(selectedSpecial.particleSystem, transform, false) as GameObject;
    g.transform.position = new Vector3(targetCharacter.transform.position.x, targetCharacter.transform.position.y + 1, targetCharacter.transform.position.z);
    Debug.Log(attackingCharacter.name + " is using " + selectedSpecial.name + " on " + targetCharacter.name);
    }
     * */


}
