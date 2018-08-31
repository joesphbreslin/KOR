using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class TBC_Specials : MonoBehaviour {

    public float    doubleDamageMult = 2, 
                    damageMult = 1, 
                    reducedDamageMult = .5f;

    public float damageRandomRange = .5f;

    public void Special(TBC_Character _attacker, TBC_Character _reciever, Specials _special)
    {
       
        switch (_special.specialType)
        {
            case ESpecialType.ATTACK:
                Attack(_attacker, _reciever, _special);      //I.E. Bomb / Magic type
                break;
            case ESpecialType.RECOVER:                                          //I.E Recovery type
                Recover(_attacker, _reciever, _special);
                break;
            default:
                break;
        }
        //deduct action points
        _attacker.actionPoints -= _special.specialCost;
        //Play Particle Effect
        PlayParticleEffect(_reciever.transform, _special, 0.5f);
    }

    void Attack(TBC_Character _attacker, TBC_Character _reciever, Specials _special)
    {
       
        float damage = 0;
        if (!IsImmune(_special.element, _reciever))
        {
          
            if (_reciever.elementalWeakness.Contains(_special.element)) {
                //DoubleDamage
                damage = Damage(doubleDamageMult, damageRandomRange, _attacker, _reciever, _special);
                //Add Effect
                Effector(_special, _reciever, 1);

            } else
            {
                //RegularDamage
                damage = Damage(damageMult, damageRandomRange, _attacker, _reciever, _special);
                //Add Effect
                Effector(_special, _reciever, 2);
            }
        }
        else
        {
            //HalfDamage
            damage = Damage(reducedDamageMult, damageRandomRange, _attacker, _reciever, _special);           
        }
        //Add Damage
        _reciever.hitPoints -= damage;    
    }

    void Recover(TBC_Character _attacker, TBC_Character _reciever, Specials _special)
    {
        
        int effectIndex = (int)_reciever.currentEffect;

        if (_special.recovery == ERecovery.REMEDY)
        {
            _reciever.currentEffect = EEffect.NONE;
        }
        else if(_special.recovery == (ERecovery)effectIndex)
        {
            _reciever.currentEffect = EEffect.NONE;
        }else if (_special.recovery == ERecovery.CURE)
        {
            _reciever.hitPoints += Cure(_attacker, _special);
        }
        else
        {
            return;
        }
    }

    // Damage() retuns a damage value for use with special moves| 
    // Algorithm: mult = Ran(mult - attackRange, mult + attackRange); 
    // return _attacker.tbc_character.attack + SpecialModifier - reciever.TBC_Character.defence * mult;

    float Damage(float _damageMult,float damageRange, TBC_Character _attacker, TBC_Character _reciever, Specials _special)
    {
        float mult = Random.Range(_damageMult - damageRange, _damageMult + damageRange);
        return (_attacker.attack + _special.specialMod - _reciever.defence) * mult;
    }

    float Cure(TBC_Character _attacker, Specials _special)
    {
        return _attacker.attack + _special.specialMod;        
    }

    bool IsImmune(EElement element, TBC_Character _reciever)
    {
        if (_reciever.elementalResistance.Contains(element))
            return true;
        else
            return false;
    }

    void PlayParticleEffect(Transform _reciever, Specials _special, float _yMod)
    {
        GameObject g = Instantiate(_special.particleSystem, transform, false) as GameObject;
        g.transform.position = new Vector3(_reciever.position.x, _reciever.position.y + _yMod, _reciever.position.z);
    }

    void Effector(Specials _special, TBC_Character _reciever, float probability)
    {
        if (_special.element > 0)
        {
            if (Random.Range(0, probability) <= 1)
            {
                int effectIndex = (int)_special.element;
                _reciever.currentEffect = (EEffect)effectIndex;
                Debug.Log(_reciever.currentEffect);
            }
            else return;
        }
    }



}
