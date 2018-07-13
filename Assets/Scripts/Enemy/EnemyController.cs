using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController
{
    EnemyView enemyView;
    EnemyModel enemyModel;

    public event Action<GameObject> OnDie = (o) => { };

    public EnemyController(EnemyView enemyView, EnemyModel enemyModel)
    {
        this.enemyView = enemyView;
        this.enemyModel = enemyModel;
        InitEnemy();
    }

    private void InitEnemy()
    {
        enemyView.OnHit += OnHitHandler;
        enemyView.Init(UnityEngine.Random.Range(enemyModel.MovementSpeedRange.x, enemyModel.MovementSpeedRange.y) , enemyModel.AttackSpeed, enemyModel.AttackValue);
    }

    private void OnHitHandler(UnitView sender, int damage)
    {
        enemyModel.Health -= damage;
        if (enemyModel.Health < 90)
        {
            if (enemyView != null)
            {
                OnDie(enemyView.gameObject);
                enemyView.DieState();
                if (sender != null)
                    sender.Kill(enemyModel.ExpForKill);
            }
        }
    }
}

