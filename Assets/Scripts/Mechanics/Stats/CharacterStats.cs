using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int damage;
    public int stunDamage;
    public int maxHealth;
    [SerializeField] private int currentHealt;

    private void Start()
    {
        currentHealt=maxHealth;
    }

    public void takeDamge(int _damage)
    {
        currentHealt-=damage;
    }
}
