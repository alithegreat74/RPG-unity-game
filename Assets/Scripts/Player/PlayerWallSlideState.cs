using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
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
        player.setVelocity(player.rb.velocity.x,0.7f*player.rb.velocity.y);
        if (!player.wallDetected() || player.groundDetected())
            stateMachine.ChangeState(player.idleState);
        if (Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(player.wallJumpState);
    }
}
