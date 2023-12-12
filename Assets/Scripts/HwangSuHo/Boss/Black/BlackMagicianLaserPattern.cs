using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagicianLaserPattern : BossBaseState
{
    float _count = 0, _maxCount;
    public override void Enter()
    {
        StateMachine.BlackMagician.LaserSummon(true);
    }
    public override void Exit()
    {

    }
    public override void Perform()
    {
        if (_count < _maxCount)
            _count += Time.deltaTime;
        else
        {
            StateMachine.BlackMagician.LaserSummon(false);
            StateMachine.ChangeState(new BlackMagicianIdle());
        }
    }
}
