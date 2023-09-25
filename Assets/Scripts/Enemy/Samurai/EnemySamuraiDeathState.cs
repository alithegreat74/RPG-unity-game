using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiDeathState : EnemyState
{
    private EnemySamurai samurai;
    public EnemySamuraiDeathState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName,EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName)
    {
        this.samurai = _samurai;
    }

    public override void Enter()
    {
        base.Enter();
        samurai.setVelocity(0, 0);
        timer=3f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer<=0)
        {
            samurai.remove();
        }
    }
}
