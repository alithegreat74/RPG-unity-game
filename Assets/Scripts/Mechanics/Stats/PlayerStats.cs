using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    protected override void die()
    {
        base.die();
        player.stateMachine.ChangeState(player.deathState);
        player.isDead=true;
    }

    public override void takeDamge(int _damage)
    {
        base.takeDamge(_damage);
        NotifyObservers(currentHealth);

    }

    protected override void Start()
    {
        base.Start();
    }
}
