using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]

public class Enemy : ScriptableObject
{
    public enum EnemyType { FIRE, WATER, CYBER, ROBOTIC, ICE, EARTH, POISON };

    [HideInInspector]
    public Transform EnemyTransform;

    [Header("EnemyType: ")]
    public EnemyType enemyType;

    [Header("Enemy Title: ")]
    public string title;

    [Header("Enemy Sprite Position: ")]
    public Vector2 position;

    [Header("Enemy Sprite: ")]
    public Sprite sprite;

    [Header("Stats")]
    public float hitPoints,
                    strength,
                    defence,
                    attack,
                    agility,
                    stamina;

}

