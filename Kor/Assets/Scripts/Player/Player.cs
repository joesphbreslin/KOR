/* Joey Breslin 11/07/2018
 * Player Object Used as bolier plate for Player creation  */

using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]

public class Player : ScriptableObject
{

    [Space(10)]
    public string playerTitle;

    [Space(10)]
    public Sprite playerMenuSprite;

    [Header("Stats")]
    public float hitPoints;

    public float strength,
                    defence,
                    attack,
                    agility,
                    stamina;


    [HideInInspector]
    public Vector2 playerPosition;

}

