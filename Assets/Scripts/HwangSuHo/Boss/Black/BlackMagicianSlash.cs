using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagicianSlash : BossBaseState
{
    float _firstSlashReadyCount;
    float _secondSlashReadyCount;
    float _thirdSlashReadyCount;
    float _thirdSlashAfterCount;

    float _countClock;
    int _slashTh;
    public override void Enter()
    {
        _firstSlashReadyCount = StateMachine.BlackMagician.FirstSlashReadyCount;
         _secondSlashReadyCount = StateMachine.BlackMagician.SecondSlashReadyCount;
         _thirdSlashReadyCount = StateMachine.BlackMagician.ThirdSlashReadyCount;
         _thirdSlashAfterCount = StateMachine.BlackMagician.ThirdSlashAfterCount;
    }
    public override void Exit()
    {
        StateMachine.BlackMagician.IsSlashing = false;

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
                    StateMachine.BlackMagician.IsSlashing = true;
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 1:
                if (_countClock < _secondSlashReadyCount)
                {
                    StateMachine.BlackMagician.IsSlashing = false;
                    _countClock += Time.deltaTime;
                }
                else
                {
                    StateMachine.BlackMagician.IsSlashing = true;
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 2:
                if (_countClock < _thirdSlashReadyCount)
                {
                    StateMachine.BlackMagician.IsSlashing = false;
                    _countClock += Time.deltaTime;
                }
                else
                {
                    StateMachine.BlackMagician.IsSlashing = true;
                    StateMachine.BlackMagician.MotionAnimator.SetTrigger("Slash");
                    _countClock = 0;
                    _slashTh++;
                }
                break;
            case 3:
                if (_countClock < _thirdSlashAfterCount)
                {
                    _countClock += Time.deltaTime;
                    StateMachine.BlackMagician.IsSlashing = false;
                }
                else
                {
                    StateMachine.ChangeState(new BlackMagicianIdle());
                }
                break;
        }
    }
}