using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation :MonoBehaviour
{
    private Player player;
    private void Awake()
    {
        player=GetComponentInParent<Player>();  
    }
    public void animationEndTrigger()
    {
        player.animationTrigger();
    }
    private void attackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackPoint.position, player.attackRadius);
        foreach(var collider in colliders)
        {
            if (collider.GetComponent<Enemy>()!=null)
            {
                Enemy enemy=collider.GetComponent<Enemy>();
                CharacterStats target=collider.GetComponent<CharacterStats>();
                if (enemy.canGetStunned())
                    player.stats.doStunDamage(target);
                else
                {
                    enemy.damage(player.facingDirection);
                    player.stats.doDamage(target);
                }
            }
            
        }
    }
}
