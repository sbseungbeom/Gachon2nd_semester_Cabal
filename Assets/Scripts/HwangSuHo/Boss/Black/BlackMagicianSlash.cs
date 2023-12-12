using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagicianSlash : BossBaseState
{
    float _firstSlashReadyCount = 1.8f;
    float _secondSlashReadyCount = 1.5f;
    float _thirdSlashReadyCount = 3f;
    float _thirdSlashAfterCount = 3f;

    float _countClock;
    int _slashTh;
    public override void Enter()
    {

    }
    public override void Exit()
    {

    }
    public override void Perform()
    {
        switch (_slashTh)
        {
            case 0:
                if (_countClock < _firstSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 1:
                if (_countClock < _secondSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 2:
                if (_countClock < _thirdSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 3:
                if (_countClock < _thirdSlashAfterCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.ChangeState(new BlackMagicianIdle());
                }
                break;
        }
    }
}