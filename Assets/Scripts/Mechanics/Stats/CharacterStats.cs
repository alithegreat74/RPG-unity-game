using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterStats : HealthSubject
{
    public Stat damage;
    public Stat stunDamage;
    public Stat maxHealth;
    [SerializeField] protected int currentHealth;

    protected virtual void Start()
    {
        currentHealth=maxHealth.getValue();
    }
    public virtual void doDamage(CharacterStats _target)
    {
        int finalDamage=damage.getValue();

        _target.takeDamge(finalDamage);
    }
    public virtual void doStunDamage(CharacterStats _target)
    {
        _target.takeDamge(stunDamage.getValue());
    }
    public virtual void takeDamge(int _damage)
    {
        currentHealth-=_damage;

        if(currentHealth <= 0)
        {
            die();
        }
    }
    protected virtual void die()
    {
        
    }
    
}
