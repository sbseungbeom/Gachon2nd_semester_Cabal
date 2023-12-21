using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMageIdleState : BossBaseState
{
    float _count = 0, _maxcount = 1;
    public override void Enter()
    {
    }

    public override void Exit()
    {
    }

    public override void Perform()
    {
        StateMachine.WhiteMagician.SecondPhaseCheck();      
            if (_count < _maxcount)
            _count += Time.deltaTime;
        else
        {
            int a = 0;
            switch (a)
            {
                case 0:
                    StateMachine.ChangeState(new WhiteMageWeakShotState());
                    break;
            }
            //아이들 카운트 if 문
        }
        //랜덤 스위치문 틀기
    }
}
