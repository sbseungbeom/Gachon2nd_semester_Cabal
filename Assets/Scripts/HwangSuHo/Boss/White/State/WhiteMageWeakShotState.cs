using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageWeakShotState : BossBaseState
{
    public override void Enter()
    {
        StateMachine.WhiteMagician.Phase2Animator.SetBool("Cast", true);
        //if(StateMachine.WhiteMagician.SecPhase)
        //속성 고정  

        //오브젝트 풀링에서 처리하게
    }

    public override void Exit()
    {
        StateMachine.WhiteMagician.Phase2Animator.SetBool("Cast", false);
    }

    public override void Perform()
    {
        //기다렸다가 idle로
    }
}
