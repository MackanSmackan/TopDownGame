using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GhostOrbValues", order = 1)]
public class GhostOrbObject : ScriptableObject
{
    [Header("NormalValues")]
    public int Damage;
    public float Speed;
    public int Health;

    [Header("Lounging")]
    public float LoungeSpeed;
    public float LoungeDistance;
    public float LoungePower;
    public float BaseSpeed;
}
