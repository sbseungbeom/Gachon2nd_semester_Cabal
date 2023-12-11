using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMage : Entity
{
    int _maxHp = 300;
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
        HP = _maxHp;
        _stateMachine = GetComponent<BossStateMachine>();
        _stateMachine.ChangeState(new WhiteMageIdleState());
    }
    private void Update()
    {
        RenderHealth();
    }
    private void RenderHealth()
    {
        BossHPGraphRenderer.Instance.Render(HP / _maxHp);
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
