using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySamurai : Enemy
{
    #region Variables
    [Header("Time Info")]
    public float idleTime;
    public float walkTime;

    [Header("Walk Info")]
    public float walkSpeed;

    [Header("Player Detection")]
    public float playerDetectionDistance;
    public float strikingDistance;
    public float disengageDistance;

    


    private Transform player;

    [SerializeField]private LayerMask whatIsPlayer;
    #endregion
    #region States
    public EnemySamuraiIdleState idleState { get; private set; }
    public EnemySamuraiWalkState walkState { get; private set; }
    public EnemySamuraiBattleState battleState { get; private set; }
    public EnemySamuraiAttackState attackState { get; private set; }
    public EnemySamuraiStunState stunState { get; private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        idleState=new EnemySamuraiIdleState(this, stateMachine, "Idle", this);
        walkState=new EnemySamuraiWalkState(this, stateMachine, "Walk", this);
        battleState=new EnemySamuraiBattleState(this, stateMachine, "Run", this);
        attackState=new EnemySamuraiAttackState(this, stateMachine, "Attack", this);
        stunState=new EnemySamuraiStunState(this, stateMachine, "Stunned", this);
        player=GameObject.Find("Player").transform;
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
        
    }
    public float playerDistance()=>Vector2.Distance(transform.position, player.position);
    public bool playerDetection()
    {
        if (Vector2.Distance(transform.position, player.position)<playerDetectionDistance)
            return true;
        else
            return false;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(wallcheck.position, new Vector3(wallcheck.position.x + playerDetectionDistance, wallcheck.position.y));
        Gizmos.color= Color.yellow;
        Gizmos.DrawLine(wallcheck.position,new Vector3(wallcheck.position.x+strikingDistance, wallcheck.position.y));
    }
    public void animationFinishTrigger()
    {
        stateMachine.currentState.isAnimationTriggered = true;
    }
    public override bool canGetStunned()
    {
        if (base.canGetStunned())
        {
            stateMachine.ChangeState(stunState);
            return true;
        }
        return false;
    }
}
