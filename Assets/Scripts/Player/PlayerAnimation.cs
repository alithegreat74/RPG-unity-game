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
                collider.GetComponent<Enemy>().damage(player.facingDirection);
        }
    }
}
