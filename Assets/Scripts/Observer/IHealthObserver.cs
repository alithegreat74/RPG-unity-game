using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthObserver 
{
    public void Notify(int value);
}
