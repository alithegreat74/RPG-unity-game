using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthSubject : MonoBehaviour
{
    private List<IHealthObserver> _observers=new List<IHealthObserver>();

    public void AddObserver(IHealthObserver observer)
    {
        _observers.Add(observer);
    }
    public void RemoveObserver(IHealthObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(int value)
    {
        foreach (IHealthObserver observer in _observers)
        {
            observer.Notify(value);
        }
    }
}
