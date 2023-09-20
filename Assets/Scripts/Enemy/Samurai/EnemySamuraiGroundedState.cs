using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiGroundedState : EnemyState
{
    protected EnemySamurai samurai;
    public EnemySamuraiGroundedState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName)
    {
        this.samurai = _samurai;
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
        if (samurai.playerDetection() && Time.time>samurai.lastTimeAttack + samurai.attackCooldown && !samurai.wallDetected())
            stateMachine.ChangeState(samurai.battleState);
    }
}
