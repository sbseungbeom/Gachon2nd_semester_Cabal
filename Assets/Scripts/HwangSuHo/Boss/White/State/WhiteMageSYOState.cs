using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageSYOState : BossBaseState
{
    float _count = 0, _maxcount = 5;
    public override void Enter()
    {
        StateMachine.WhiteMagician.SYO.StartFist();
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        if (_count < _maxcount)
            _count += Time.deltaTime;
        else
            StateMachine.ChangeState(new WhiteMageSecondIdle());
    }
}
