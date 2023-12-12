using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagicianClaw : BossBaseState
{
    float _count;
    float _readyCount;
    float _afterCount;
    public override void Enter()
    {
        throw new System.NotImplementedException();
    }

    public override void Exit()
    {
        throw new System.NotImplementedException();
    }

    public override void Perform()
    {
        if (_count < _readyCount)
            _count += Time.deltaTime;
        else
        {

            //팔 휘두르기 애니메이션
            //Hovl 스튜디오의 지상 쇼크웨이브 애니메이션
            //판정 애니메이션
            //dile로 넘기기
        }
    }
}
