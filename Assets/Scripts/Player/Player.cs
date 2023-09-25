using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public PlayerStateMachine stateMachine { get; private set; }
    #region States
    public PlayerIdleState idleState {get;private set;}
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set;}
    public PlayerFallState fallState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }
    public PlayerDeathState deathState { get; private set; }

    #endregion
    #region Variable
    [Header("DashInfo")]
    public float dashSpeed;
    public float dashTime;
    public float dashCooldown;
    protected float dashDirection;
    protected float dashCooldownTimer;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        stateMachine=new PlayerStateMachine();
        idleState=new PlayerIdleState(this, stateMachine, "Idle");
        moveState=new PlayerMoveState(this, stateMachine, "Run");
        jumpState=new PlayerJumpState(this, stateMachine, "Air");
        fallState=new PlayerFallState(this, stateMachine, "Air");
        dashState=new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState=new PlayerWallSlideState(this, stateMachine, "Wall Slide");
        wallJumpState=new PlayerWallJumpState(this, stateMachine, "Air");
        primaryAttackState=new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        deathState=new PlayerDeathState(this, stateMachine, "Death");
    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        dash();
    }


    private void dash()
    {
        dashDirection=dashDirection==0 ? dashDirection=facingDirection : Input.GetAxisRaw("Horizontal");

        dashCooldownTimer-=Time.deltaTime;

        if(Input.GetKey(KeyCode.LeftShift) && dashCooldownTimer<0) 
        {
            dashCooldownTimer=dashCooldown;
            stateMachine.ChangeState(dashState);
        }
    }
    
    public void animationTrigger()
    {
        animator.SetBool("Attack", false);
        stateMachine.ChangeState(idleState);
    }
    public IEnumerator busyFor(float _secconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_secconds);
        isBusy= false;
    }

}
