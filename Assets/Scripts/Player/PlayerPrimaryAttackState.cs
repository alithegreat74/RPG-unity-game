using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private float comboDuration=0.4f;
    private float lastAttackTime;
    private int comboCount;
    public PlayerPrimaryAttackState(Player _player, PlayerStateMachine _stateMachine, string _animationBoolName) : base(_player, _stateMachine, _animationBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        if(Time.time> lastAttackTime + comboDuration)
        {
            comboCount=0;
        }
        comboCount%=2;
        player.animator.SetInteger("comboCount", comboCount);
        timer=0.2f;
        player.setVelocity(player.attackMovement[comboCount]*player.facingDirection*player.moveSpeed, player.rb.velocity.y);
        
    }

    public override void Exit()
    {
        base.Exit();
        lastAttackTime=Time.time;
        comboCount++;
        player.StartCoroutine("busyFor", 0.15f);
    }

    public override void Update()
    {
        base.Update();
        if(timer<0)
            player.setVelocity(0, 0);
        
    }
}
