using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : UnitView
{
    protected float movementSpeed;
    protected float attackSpeed;
    protected int attackValue;

    protected StateMachine stateMachine;

    public void Init(float movementSpeed, float attackSpeed, int attackValue)
    {
        this.movementSpeed = movementSpeed;
        this.attackSpeed = attackSpeed;
        this.attackValue = attackValue;

        stateMachine = new StateMachine();
        MovableState();
    }

    protected void Update()
    {
        stateMachine.Update();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fort")
            stateMachine.ChangeState(new AttackState(this, collision.gameObject.GetComponent<UnitView>(), attackSpeed, attackValue));
    }

    public override void ReceiveDamage(UnitView sender, int dmg)
    {
        base.ReceiveDamage(sender, dmg);
        try
        {
            GameObject splash = SplashPool.Instance.GetSplash();
            splash.transform.parent = transform;
            splash.transform.localPosition = Vector3.zero;
        }
        catch (MissingReferenceException ex)
        {
            Debug.Log(ex.StackTrace);
        }
    }

    public void MovableState()
    {
        stateMachine.ChangeState(new EnemyWalkState(this, movementSpeed));
    }

    public void DieState()
    {
        stateMachine.ChangeState(new DieState(this));
    }
}


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