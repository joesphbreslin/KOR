
namespace Types {
    public enum EArea { AREA_1, AREA_2, AREA_3, AREA_4, AREA_5, AREA_6 , NONE} //TODO Replace with real locations
    public enum ECharacterElement { FIRE, WATER, CYBER, ROBOTIC, ICE, EARTH, POISON, LIGHTNING, NONE }; //REVISE THIS

    public enum EActionKey { IDLE, ATTACK_A, ATTACK_B, ATTACK_C, DEATH, DAMAGED, NONE };
    public enum EDialogueKey { DEFEATED, VICTORIOUS, WINNING, LOSING, SUPRISE, RANSOM, NONE };
    public enum ECharacterType { PLAYER, FRIEND, ENEMY, NPC, NONE };

    public enum ESpecialType {NONE=0,ATTACK=1, RECOVER=2}; // anything > 0 is inculded in attack effectors and specific recovery effects, remedy fixes all aliments.
                                                        // anything <=0 does not have effectors only damage and healing properties.
    public enum EElement {WATER=-3, LIGHTNING=-2, ICE=-1,   NONE=0,     FIRE=1,     POISON=2,       CYBER=3,    FLASH=4,    GAS=5};
    public enum EEffect  {                                  NONE=0,     BURNED=1,   POISONED=2,     HACKED=3,   STUNNED=4,  SLEEP=5 };
    public enum ERecovery {CURE=-1,                         NONE=0,     AGUA=1,     ANTIDOTE=2,     FIREWALL=3, SALTS=4,    CAFFINE=5, REMEDY=6};

   
    public enum EItemType {EQUIPMENT, WEAPON, BOOK, RECOVERY, DAMAGE , NONE};
   

}

