using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void Exit()
    {
        base.Exit();
        player.setVelocity(0, 0);
    }

    public override void Update()
    {
        base.Update();

        player.setVelocity(xInput*player.moveSpeed, player.rb.velocity.y);
        
        if (xInput==0 || player.wallDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
