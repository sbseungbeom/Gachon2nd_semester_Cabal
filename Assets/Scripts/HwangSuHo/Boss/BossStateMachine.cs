using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public BlackMagician BlackMagician;
    public WhiteMage WhiteMagician;
    BossBaseState _currentState;
    private void Update()
    {
        Perform();
    }
    public void ChangeState(BossBaseState state)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = state;
        _currentState.StateMachine = this;
        _currentState.Enter();
    }
    public void Perform()
    {
        _currentState.Perform();
    }
}
