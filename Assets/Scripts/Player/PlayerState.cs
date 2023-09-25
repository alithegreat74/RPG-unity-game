using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected string animationBoolName;
    protected float timer;
    protected float xInput;
    protected Inventory inventory;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine,string _animationBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animationBoolName = _animationBoolName;

    }

    public virtual void Enter()
    {
        player.animator.SetBool(animationBoolName, true);
        inventory=Inventory.instance;
        

    }
    public virtual void Update()
    {
        xInput=Input.GetAxisRaw("Horizontal");
        player.animator.SetFloat("yVelocity", player.rb.velocity.y);
        if (player.facingDirection==-1*xInput)
            player.flip();

        timer-=Time.deltaTime;

        if (!inventory.activeUI && Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Open Inventory");
            inventory.enableUI();
            stateMachine.ChangeState(player.idleState);
        }

    }
    public virtual void Exit()
    {
        player.animator.SetBool(animationBoolName, false);
    }
}
