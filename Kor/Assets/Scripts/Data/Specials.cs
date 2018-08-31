using UnityEngine;
using Types;

[CreateAssetMenu(fileName ="New Special", menuName = "Special")]

public class Specials : ScriptableObject {

    public string specialName;
    public EElement element;
    public ERecovery recovery;
    public ESpecialType specialType;

    public float attackMod;
    public float recoverMod;
    public int specialMod;

    public GameObject particleSystem;

}
