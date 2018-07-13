using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyWalkState : IState
{
    private EnemyView owner;
    private float speed;

    public EnemyWalkState(EnemyView owner, float speed)
    {
        this.owner = owner;
        this.speed = speed;
    }

    public void Enter()
    {
        owner.GetComponent<Animator>().SetTrigger("Walk");
    }

    public void Execute()
    {
        owner.transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));
    }

    public void Exit()
    {
    }
}