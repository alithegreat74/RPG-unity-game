using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Stun Info")]
    public float stunDuration;
    public Vector2 stunDirection;
    [SerializeField]protected bool canBeStunned;
    [SerializeField]private GameObject stunWarning;

    #region States
    [Header("Attack Info")]
    public float attackCooldown;
    [HideInInspector] public float lastTimeAttack;
    public EnemyStateMachine stateMachine { get; private set; }

    #endregion
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public void openStunWindow()
    {
        canBeStunned= true;
        stunWarning.SetActive(true);
    }
    public void closeStunWindow()
    {
        canBeStunned= false;
        stunWarning.SetActive(false);
    }
    public  virtual bool canGetStunned()
    {
        if (canBeStunned)
        {
            closeStunWindow();
            return true;
        }
        return false;
    }



}
