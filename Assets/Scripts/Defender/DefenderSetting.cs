using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "DefenderSetting", menuName = "DefenderSetting", order = 1)]
public class DefenderSetting : ScriptableObject
{
    public float AttackSpeed;
    public int Experience;
    public int AttackValue;
    public int StartLevel;

    public DefenderUnitLevel[] DefenderLevels;
}
[Serializable]
public class DefenderUnitLevel
{
    public Sprite UnitSprite;
    public GameObject UnitPrefab;
    public int ExpToNextLvl;
    public int AtkValue;
}