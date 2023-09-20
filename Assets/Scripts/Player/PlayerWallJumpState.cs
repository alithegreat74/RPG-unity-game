using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.setVelocity(3*-1*player.facingDirection, 15);
        timer=0.3f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer<0)
            stateMachine.ChangeState(player.fallState);
    }
}
