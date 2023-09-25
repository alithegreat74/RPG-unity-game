using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiBattleState : EnemySamuraiGroundedState
{
    private Transform player;
    
    private int playerDirection;

    public EnemySamuraiBattleState(Enemy _enemy, EnemyStateMachine _stateMachine, string _animationBoolName, EnemySamurai _samurai) : base(_enemy, _stateMachine, _animationBoolName, _samurai)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player=PlayerManager.instance.player.transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (samurai.wallDetected())
            stateMachine.ChangeState(samurai.idleState);

        if (player.position.x > samurai.transform.position.x)
            playerDirection=1;
        else if(player.position.x < samurai.transform.position.x)
            playerDirection=-1;
        samurai.setVelocity(samurai.moveSpeed*playerDirection, rb.velocity.y);

        if (samurai.facingDirection==-1*playerDirection && samurai.playerDistance()>samurai.strikingDistance)
            samurai.flip();

        if(samurai.playerDistance() < samurai.strikingDistance)
        {
            if (canAttack())
                stateMachine.ChangeState(samurai.attackState);
        }
        if (!samurai.playerDetection())
        {
            stateMachine.ChangeState(samurai.idleState);
        }

        if (player.gameObject.GetComponent<Player>().isDead)
            stateMachine.ChangeState(samurai.idleState);

    }

    private bool canAttack()
    {
        if (Time.time>samurai.lastTimeAttack+samurai.attackCooldown && !samurai.isKnocked)
        {
            samurai.lastTimeAttack= Time.time;
            return true;
        }

        return false;
    }
}
