using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefenderController
{
    DefenderView defenderView;
    DefenderModel defenderModel;
    DefenderViewUi defenderViewUi;

    public DefenderController(DefenderView defenderView, DefenderModel defenderModel, DefenderViewUi defenderViewUi)
    {
        this.defenderView = defenderView;
        this.defenderModel = defenderModel;
        this.defenderViewUi = defenderViewUi;

        DefenderInit();
    }

    private void DefenderInit()
    {
        defenderView.OnKill += OnKillHandler;
        defenderModel.OnExpChanged += defenderViewUi.OnExpChangedHandler;
        defenderModel.OnLvlUp += defenderViewUi.CurrentLevelInitialize;
        defenderModel.OnLvlUp += defenderView.InitializeDefenderView;

        defenderModel.Experience = 0;
        defenderModel.CurrentLevel = 0;
        defenderView.Init(defenderModel.AttackSpeed, defenderModel.AttackValue);
    }

    private void OnKillHandler(int ExpForKill)
    {
        defenderModel.Experience += ExpForKill;
    }

    public void OnTargetDieHandler(GameObject target)
    {
        defenderView.OnTargetDieHandler(target);
    }
}

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