using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : MonoBehaviour
{
    public BlackMagician BlackMagician;
    BossBaseState _currentState;
    private void Update()
    {
        Perform();
    }
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
