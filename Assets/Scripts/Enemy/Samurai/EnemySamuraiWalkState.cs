using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiWalkState : EnemySamuraiGroundedState
{
    public EnemySamuraiWalkState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName, _samurai)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer=samurai.walkTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        samurai.setVelocity(samurai.walkSpeed*samurai.facingDirection, rb.velocity.y);
        if (samurai.wallDetected() || !samurai.groundDetected())
            enemy.flip();
        if (timer<0)
            stateMachine.ChangeState(samurai.idleState);
        
    }
}
