using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DieState : IState
{
    private UnitView owner;
    private float speed;

    public DieState(UnitView owner)
    {
        this.owner = owner;
    }

    public void Enter()
    {
        owner.GetComponent<Animator>().SetTrigger("Die");
    }

    public void Execute()
    {
        if (owner.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Dead"))
        {
            Object.Destroy(owner.gameObject);
        }
    }

    public void Exit()
    {

    }
}