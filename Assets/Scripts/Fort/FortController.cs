using UnityEngine;
using System;

public class FortController
{
    private FortView fortView;
    private FortModel fortModel;
    private FortViewUi fortViewUi;
    private LevelModel levelModel;
    public static event Action OnFortDestroyed =()=> { };

    public FortController(FortView fortView, FortViewUi fortViewUi, LevelModel levelModel)
    {
        this.fortView = fortView;
        this.fortViewUi = fortViewUi;
        this.fortView.OnHit += OnHitHandler;
        this.levelModel = levelModel;

        fortModel = new FortModel();
        this.fortViewUi.Inititalization(fortModel);
        this.fortView.SetFortState(FortModel.DestructionState.None);
    }

    public void Init(FortView fortView, FortViewUi fortViewUi, LevelModel levelModel)
    {
        this.fortView = fortView;
        this.fortViewUi = fortViewUi;
        this.levelModel = levelModel;

        fortModel = new FortModel();
        this.fortViewUi.Inititalization(fortModel);
        this.fortView.SetFortState(FortModel.DestructionState.None);
    }

    public void OnHitHandler(UnitView unitView, int damage)
    {
        fortModel.CurrentHealth -= damage;
        fortViewUi.SetupCurrentHealth(fortModel.CurrentHealth);

        float destrVal = (1f - (fortModel.CurrentHealth / (float)fortModel.MaxHP));

        if (destrVal > 0.9f)
            fortView.SetFortState(FortModel.DestructionState.Major);
        else if (destrVal > 0.6f)
            fortView.SetFortState(FortModel.DestructionState.Minor);
        else if (destrVal > 0.3f)
            fortView.SetFortState(FortModel.DestructionState.Low);
        
        if (fortModel.CurrentHealth <= 0)
        {
            OnFortDestroyed();
        }
    }
}

public class FortModel
{
    public int MaxHP = 300;
    public int CurrentHealth;
    public DestructionState CurrentDestrState;


    public FortModel()
    {
        CurrentHealth = MaxHP;
        CurrentDestrState = DestructionState.None;
    }

    public enum DestructionState
    {
        None,
        Low,
        Minor,
        Major
    }
}
