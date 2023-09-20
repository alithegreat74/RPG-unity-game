using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiAttackState : EnemyState
{
    private EnemySamurai samurai;
    

    public EnemySamuraiAttackState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName)
    {
        this.samurai=_samurai;
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        samurai.setVelocity(0, 0);

        if (isAnimationTriggered)
            stateMachine.ChangeState(samurai.idleState);
    }
}
