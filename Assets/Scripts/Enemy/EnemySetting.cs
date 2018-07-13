using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySetting", menuName = "EnemySetting", order = 1)]
public class EnemySetting : ScriptableObject
{
    public float AttackSpeed;
    public Vector2 MovementSpeedRange;
    public int Health;
    public int AttackValue;
    public int ExpForKill;
}