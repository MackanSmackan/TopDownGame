using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyValues", order = 1)]
public class EnemyObject : ScriptableObject
{
    [Header("Both")]
    public int Health;
    public int Damage;
    public float Speed;

    [Header("Ghost orbs")]
    public float LoungeSpeed;
    public float LoungeDistance;
    public float LoungePower;
    public float BaseSpeed;

    [Header("Goblins")]
    public float Radius;
    public float CircleSpeed;
}
