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
            //���̵� ī��Ʈ if ��
        }
        //���� ����ġ�� Ʋ��
    }
}
