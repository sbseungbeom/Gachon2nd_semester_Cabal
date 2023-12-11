using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageSYOState : BossBaseState
{
    public override void Enter()
    {
        StateMachine.WhiteMagician.SYO.StartFist();
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
    }
}
