using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiStunState : EnemyState
{
    private EnemySamurai samurai;
    public EnemySamuraiStunState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName,EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName)
    {
        this.samurai= _samurai;
    }

    public override void Enter()
    {
        base.Enter();
        samurai.setVelocity(samurai.stunDirection.x * samurai.facingDirection * -1, samurai.stunDirection.y);
        timer=samurai.stunDuration;
        samurai.entityFx.InvokeRepeating("redBlink", 0, 0.1f);

    }

    public override void Exit()
    {
        base.Exit();
        samurai.entityFx.Invoke("cancelBlink", 0);
    }

    public override void Update()
    {
        base.Update();
        if (timer<0)
        {
            stateMachine.ChangeState(samurai.idleState);
        }
    }
}
