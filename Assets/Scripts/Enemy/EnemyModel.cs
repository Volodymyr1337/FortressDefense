using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyModel
{
    public float AttackSpeed;
    public Vector2 MovementSpeedRange;
    public int Health;
    public int AttackValue;
    public int ExpForKill;

    public EnemyModel(EnemySetting enemySetting)
    {
        AttackSpeed = enemySetting.AttackSpeed;
        MovementSpeedRange = enemySetting.MovementSpeedRange;
        Health = enemySetting.Health;
        AttackValue = enemySetting.AttackValue;
        ExpForKill = enemySetting.ExpForKill;
    }
}