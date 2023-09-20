using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySamuraiAnimationTrigger : MonoBehaviour
{
    private EnemySamurai samurai;
    private void Awake()
    {
        samurai=GetComponentInParent<EnemySamurai>();
    }
    public void triggerAnimation()
    {
        samurai.animationFinishTrigger();
    }
    private void attackTrigger()
    {
        Collider2D[] colliders=Physics2D.OverlapCircleAll(samurai.attackPoint.position,samurai.attackRadius);  
        foreach(var collider in colliders)
        {
            if (collider.GetComponent<Player>()!=null)
                collider.GetComponent<Player>().damage(samurai.facingDirection);
        }
    }
    private void openStunWindow() => samurai.openStunWindow();

    private void closeStunWindow()=>samurai.closeStunWindow();

    
}
