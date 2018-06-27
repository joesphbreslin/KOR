using UnityEngine;

[CreateAssetMenu(fileName = "New Component", menuName = "KOR Component")]
public class KorComponent : ScriptableObject
{
    public enum KorComponentType { HEAD, ARMS, LEGS, TORSO };

    [Header("KOR Component Type: ")]
    public KorComponentType korComponentType;

    [Header("Component Title: ")]
    public string title;

    [Header("Component Description: ")]
    [TextArea()]
    public string description;

    [Header("Component Position: ")]
    public Vector2 position;

    [Header("Component Sprite: ")]
    public Sprite sprite;

    [Header("Modifiers")]
    public float hitPoints,
                    strength,
                    defence,
                    attack,
                    agility,
                    stamina;





}
