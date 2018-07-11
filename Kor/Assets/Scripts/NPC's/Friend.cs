/* Joey Breslin 11/07/2018
 * Friend Object Used as bolier plate for Party Member creation  */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Friendly", menuName = "Friend")]

public class Friend : ScriptableObject {

    [Space(10)]
    public string friendTitle;

    [Space(10)]
    public Sprite friendMenuSprite;

    [Header("Stats")]
    public float hitPoints;

    public float strength,
                    defence,
                    attack,
                    agility,
                    stamina;


    [HideInInspector]
    public Vector2 friendPosition;

}

