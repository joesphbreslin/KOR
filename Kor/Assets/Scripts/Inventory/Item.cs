using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class Item : ScriptableObject
{
    public EItemType itemType;

    public string itemName;
    public int itemValue;

    public EItemEffect itemEffect;
    public int itemEffectMod;

    public GameObject particleSystem;

}
