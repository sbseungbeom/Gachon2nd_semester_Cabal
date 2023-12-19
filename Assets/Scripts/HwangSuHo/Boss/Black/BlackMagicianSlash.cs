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

    }
    public override void Perform()
    {
        switch (_slashTh)
        {
            case 0:
                if (StateMachine.BlackMagician.Turning != null)
                    StateMachine.BlackMagician.StopCoroutine(StateMachine.BlackMagician.Turning);
                if (_countClock < _firstSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    if (StateMachine.BlackMagician.Turning != null)
                        StateMachine.BlackMagician.StopCoroutine(StateMachine.BlackMagician.Turning);
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
                    if (StateMachine.BlackMagician.Turning != null)
                        StateMachine.BlackMagician.StopCoroutine(StateMachine.BlackMagician.Turning);
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
                    if (StateMachine.BlackMagician.Turning != null)
                        StateMachine.BlackMagician.StopCoroutine(StateMachine.BlackMagician.Turning);
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