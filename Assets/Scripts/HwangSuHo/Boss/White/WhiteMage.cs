using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMage : Entity
{
    Transform _playerPos;
    BossStateMachine _stateMachine;

    [SerializeField] GameObject _phase1Model;
    public Animator MotionAnimator;
    [SerializeField] GameObject _phase2Model;
    public Animator Phase2Animator { get => _phase2Model.GetComponent<Animator>(); }

    [SerializeField] float _weakHeight;
    [SerializeField] Projectile _weakDagger;

    public SunlightYellowOverdrive SYO;
    public BossLaser2 ULTLsr2;

    public bool SecPhase = false;

    [SerializeField] bool TestCase;

    public bool Ultmode { get; set; }
    int _UltStack;
    [SerializeField] int _maxUltStack;
    protected override void OnDeath()
    {
        //컷씬 넘긴 이후 밑줄 실행
        GameManager.Instance.Player.OnClear();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (TestCase)
            hp = 160;
        _stateMachine = GetComponent<BossStateMachine>();
        _stateMachine.ChangeState(new WhiteMageIdleState());
        _playerPos = GameManager.Instance.Player.transform;
    }
    private void Update()
    {
        RenderHealth();
    }
    private void RenderHealth()
    {
        BossHPGraphRenderer.Instance.Render(HP / (float)MaxHP);
    }

    //50% 남았을때 인지 아닌지 확인
    public bool SecondPhaseCheck()
    {
        if (HP < 150)
        {
            _phase2Model.gameObject.SetActive(true);
            _phase1Model.SetActive(false);
            _phase2Model.GetComponent<Animator>().SetTrigger("In");
            return true;
        }
        else
            return false;
    }
    public void DaggerSummon()
    {
        GameObject ii = Instantiate(_weakDagger, new Vector3(_playerPos.position.x, _weakHeight, _playerPos.position.z), transform.rotation).gameObject;
        ii.transform.forward = Vector3.down;
        int a = Mathf.FloorToInt(Random.Range(0, 4));
        ii.GetComponent<WhiteMageWeakS>().ModelSet(a);
    }
    public override void Damage(int damage)
    {
        base.Damage(damage);
        if (Ultmode)
        {
            _UltStack += damage;
            if (_UltStack >= _maxUltStack)
            {
                _UltStack = 0;
                Ultmode = false;
                _stateMachine.ChangeState(new WhiteMageSecondIdle());
            }
        }
    }
}
