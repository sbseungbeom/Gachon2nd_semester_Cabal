using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    BossBaseState _currentState;
    public void ChangeState(BossBaseState state)
    {
        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
    public void Perform()
    {
        _currentState.Perform();
    }
}
