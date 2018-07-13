using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderView : UnitView
{
    private StateMachine stateMachine;
    private float attackSpeed;
    private int attackValue;

    private List<GameObject> enemies = new List<GameObject>();

    private void Start()
    {
        // костыль для колчанов у лукарей, иначе отображаются выше леера юнитов :(
        Spriter2UnityDX.EntityRenderer entityRenderer = this.GetComponentInChildren<Spriter2UnityDX.EntityRenderer>();
        entityRenderer.ApplySpriterZOrder = false;
        entityRenderer.ApplySpriterZOrder = true;
    }
    public void InitializeDefenderView(DefenderUnitLevel defenderLevel)
    {
        if (transform.childCount > 0)
            for (var i = 0; i < transform.childCount; i++)
            {
               Destroy(transform.GetChild(i).gameObject);
            }

        GameObject defender = defenderLevel.UnitPrefab;
        defender.transform.position = Vector3.zero;
        Instantiate(defender, transform);
    }
    public void Init(float attackSpeed, int attackValue)
    {
        this.attackSpeed = attackSpeed;
        this.attackValue = attackValue;
        
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new DefenderIdleState(this));
    }

    void Update ()
    {
        stateMachine.Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            if (!enemies.Contains(collision.gameObject))
            {
                enemies.Add(collision.gameObject);
                stateMachine.ChangeState(new AttackState(this, collision.gameObject.GetComponent<UnitView>(), attackSpeed, attackValue));
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {            
            transform.parent.transform.right = transform.parent.transform.position - collision.transform.position;
        }
    }

    public void OnTargetDieHandler(GameObject target)
    {
        enemies.RemoveAll(item => item == null);
        enemies.Remove(target);

        if (enemies.Count == 0)
            stateMachine.ChangeState(new DefenderIdleState(this));
        else
            stateMachine.ChangeState(new AttackState(this, enemies[0].gameObject.GetComponent<UnitView>(), attackSpeed, attackValue));
    }
}

public class DefenderIdleState : IState
{
    private DefenderView owner;
    private Animator ownerAnimator;
    public DefenderIdleState(DefenderView owner) { this.owner = owner; }

    public void Enter()
    {
        ownerAnimator = owner.GetComponent<Animator>();
        if (ownerAnimator == null)
            ownerAnimator = owner.GetComponentInChildren<Animator>();

        ownerAnimator.SetTrigger("Idle");
    }

    public void Execute()
    {

    }

    public void Exit()
    {

    }
}