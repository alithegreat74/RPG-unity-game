using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiIdleState : EnemySamuraiGroundedState
{
    public EnemySamuraiIdleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName, _samurai)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer=samurai.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        samurai.setVelocity(0, 0);
        if (timer<0)
            stateMachine.ChangeState(samurai.walkState);
    }
}
