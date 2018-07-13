using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefenderModel
{
    public event Action<int> OnExpChanged = (exp) => { };
    public event Action<DefenderUnitLevel> OnLvlUp = (exp) => { };

    public float AttackSpeed;
    private int experience;
    public int Experience
    {
        get { return experience; }
        set
        {
            experience = value;
            if (experience >= DefenderUnitLevels[currentLevel].ExpToNextLvl)
            {
                experience = 0;
                CurrentLevel++;
            }

            OnExpChanged(experience);
        }
    }
    public DefenderUnitLevel[] DefenderUnitLevels;
    public int AttackValue;
    private int currentLevel;
    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            OnLvlUp(DefenderUnitLevels[currentLevel]);
        }
    }

    public DefenderModel(DefenderSetting defenderSetting)
    {
        AttackSpeed = defenderSetting.AttackSpeed;
        DefenderUnitLevels = defenderSetting.DefenderLevels;
        AttackValue = defenderSetting.AttackValue;
        CurrentLevel = defenderSetting.StartLevel;
        Experience = defenderSetting.Experience;
    }
}