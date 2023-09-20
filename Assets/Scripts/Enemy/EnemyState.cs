using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected string animationBoolName;
    protected float timer;
    protected float xInput;
    protected float yInput;
    public bool isAnimationTriggered;
    protected Rigidbody2D rb;
    public bool isHit;

    public EnemyState(Enemy _enemy,EnemyStateMachine _stateMachine,string _animationBoolName)
    {
        this.enemy = _enemy;
        this.stateMachine = _stateMachine;
        this.animationBoolName = _animationBoolName;
    }

    public virtual void Enter()
    {
        rb=enemy.rb;
        enemy.animator.SetBool(animationBoolName, true);
        isAnimationTriggered=false;
    }
    public virtual void Exit()
    {
        enemy.animator.SetBool(animationBoolName, false);
    }
    public virtual void Update()
    {
        timer-=Time.deltaTime;

    }
}
