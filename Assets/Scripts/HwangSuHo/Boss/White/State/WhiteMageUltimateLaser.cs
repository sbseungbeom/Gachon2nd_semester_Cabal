using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageUltimateLaser : BossBaseState
{
    float _count = 0;
    public override void Enter()
    {
        Debug.Log(StateMachine.WhiteMagician.ULTLsr2);
        StateMachine.WhiteMagician.Phase2Animator.SetBool("Cast", true);
        StateMachine.WhiteMagician.ULTLsr2.StartLaserAttack();
        StateMachine.WhiteMagician.Ultmode = true;
    }

    public override void Exit()
    {
        StateMachine.WhiteMagician.Phase2Animator.SetBool("Cast", false);
    }

    public override void Perform()
    {
        if (_count < 8.5f)
            _count += Time.deltaTime;
        else
        {
            StateMachine.ChangeState(new WhiteMageSecondIdle());
        }
    }
}
