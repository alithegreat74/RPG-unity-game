using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine 
{
    public EnemyState currentState { get; private set; }

    public void Initialize(EnemyState _firstState)
    {
        currentState= _firstState;
        currentState.Enter();
    }
    public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState= _newState;
        currentState.Enter();
    }
}
