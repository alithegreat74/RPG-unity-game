using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour,IHealthObserver
{
    [SerializeField] private Slider _health;
    private int _maxHealth;

    private void Start()
    {
        _maxHealth =PlayerManager.instance.player.stats.maxHealth.getValue();
        PlayerManager.instance.player.stats.AddObserver(this);
        _health.maxValue= _maxHealth;
        _health.minValue= 0;
        _health.value= _health.maxValue;
    }

    private void OnDisable()
    {
        PlayerManager.instance.player.stats.RemoveObserver(this);
    }
    public void Notify(int value)
    {
        _health.value = value;
    }
}
