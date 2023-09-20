using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        timer=player.dashTime;
    }

    public override void Exit()
    {
        base.Exit();
        player.setVelocity(0, player.rb.velocity.y);
        
    }

    public override void Update()
    {
        base.Update();
        player.setVelocity(player.dashSpeed * player.facingDirection, 0);
        if (player.wallDetected())
            stateMachine.ChangeState(player.wallSlideState);
        if (timer<0)
        {
            if(player.groundDetected())
                stateMachine.ChangeState(player.idleState);
            else
                stateMachine.ChangeState(player.fallState);
        }


        
    }
}
