using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMage : Entity
{
    BossStateMachine _stateMachine;
    public Animator MotionAnimator;
    public SunlightYellowOverdrive SYO;
    public BossLaser2 ULTLsr2;
    protected override void OnDeath()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        _stateMachine = GetComponent<BossStateMachine>();
        _stateMachine.ChangeState(new WhiteMageIdleState());
    }
    //50% 남았을때 인지 아닌지 확인
    public bool SecondPhaseCheck()
    {
        if (HP < 500)
            return true;
        else
            return false;
    }
}
