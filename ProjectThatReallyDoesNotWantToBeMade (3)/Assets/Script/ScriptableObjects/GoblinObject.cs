using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GoblinValues", order = 1)]
public class GoblinObject : ScriptableObject
{
    [Header("NormalValues")]
    public int Damage;
    public float Speed;
    public int Health;

    [Header("Goblins")]
    public float Radius;
    public float CircleSpeed;
    public bool SpinDirection;
}
