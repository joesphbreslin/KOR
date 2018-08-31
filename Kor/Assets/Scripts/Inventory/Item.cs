using Types;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]

public class Item : ScriptableObject
{
    public EItemType itemType;

    public string itemName;
    public int itemValue;

    public EEffect itemEffect;
    public int itemEffectMod;

    public GameObject itemParticleSystem;
    public string itemDescription;
    public Sprite menuSprite;

    public int itemAmount;
}
