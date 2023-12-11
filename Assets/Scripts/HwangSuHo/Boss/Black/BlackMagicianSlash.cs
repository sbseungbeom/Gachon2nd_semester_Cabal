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
                    StateMachine.BlackMagician.GetComponent<Animator>().SetTrigger("Slash");
                    _slashTh++;
                }
                break;
            case 1:
                if (_countClock < _secondSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.BlackMagician.GetComponent<Animator>().SetTrigger("Slash");
                    _slashTh++;
                }
                break;
            case 2:
                if (_countClock < _thirdSlashReadyCount)
                    _countClock += Time.deltaTime;
                else
                {
                    StateMachine.BlackMagician.GetComponent<Animator>().SetTrigger("Slash");
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
