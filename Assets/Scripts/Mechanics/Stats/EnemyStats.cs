using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    EnemySamurai samurai;

    private void Awake()
    {
        samurai=GetComponentInParent<EnemySamurai>();
    }
    public override void takeDamge(int _damage)
    {
        base.takeDamge(_damage);
        if (currentHealth<=0)
            die();
    }

    protected override void die()
    {
        base.die();
        samurai.stateMachine.ChangeState(samurai.deathState);
    }

    protected override void Start()
    {
        base.Start();
    }
}
