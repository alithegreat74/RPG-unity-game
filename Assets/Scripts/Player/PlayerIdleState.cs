using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer=1f;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        player.setVelocity(0, 0);

        if (xInput!=0 && !player.wallDetected() && !player.isBusy && !inventory.activeUI)
            stateMachine.ChangeState(player.moveState);

        if(inventory.activeUI && Input.GetKeyDown(KeyCode.I)  && timer<0)
        {
            Debug.Log("Close Inventory");
            inventory.disableUI();
        }
    }
}
