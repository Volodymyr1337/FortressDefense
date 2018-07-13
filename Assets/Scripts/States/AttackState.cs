using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackState : IState
{
    private UnitView owner;
    private Animator ownerAnimator;

    private float attackSpeed;
    private float startAtkTime;
    private int attackValue;

    private UnitView target;

    public AttackState(UnitView owner, UnitView target, float attackSpeed, int attackValue)
    {
        this.owner = owner;
        this.target = target;
        this.attackSpeed = attackSpeed;
        this.attackValue = attackValue;
    }

    public void Enter()
    {
        ownerAnimator = owner.GetComponent<Animator>();
        if (ownerAnimator == null)
            ownerAnimator = owner.GetComponentInChildren<Animator>();

        ownerAnimator.speed = 1f / attackSpeed;
        ownerAnimator.SetTrigger("Attack");

        startAtkTime = Time.time;
    }

    public void Execute()
    {
        if (Time.time - startAtkTime > attackSpeed)
        {
            startAtkTime = Time.time;
            target.ReceiveDamage(owner, attackValue);
        }
    }

    public void Exit()
    {
        //Debug.Log("exti atk");
        if (ownerAnimator != null)
            ownerAnimator.speed = 1f;
    }
}