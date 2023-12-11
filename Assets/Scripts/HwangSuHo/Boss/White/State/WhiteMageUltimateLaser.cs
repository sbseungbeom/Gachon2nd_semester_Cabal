using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageUltimateLaser : BossBaseState
{
    float _count = 0;
    public override void Enter()
    {
        StateMachine.WhiteMagician.ULTLsr2.StartLaserAttack();
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        if (_count < .27f)
            _count += Time.deltaTime;
        else
        {
            if (StateMachine.WhiteMagician.MotionAnimator.GetCurrentAnimatorStateInfo(0).IsName(""))
            {
                
            }
        }
    }
}
