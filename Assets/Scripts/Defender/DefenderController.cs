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
