using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackMagician : Entity
{
    //퍼센트 체력바용 오버라이드 체력?

    bool _isTurning;
    float _angleToPlayer;
    [SerializeField] float _rotationPow;

    [SerializeField] float _turnDegree;
    [SerializeField] float _stareDegree;

    RoundaboutMovement _player;

    public BossStateMachine StateMachine { get; private set; }
    protected override void OnDeath()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        _player = FindObjectOfType<RoundaboutMovement>();
        transform.LookAt(_player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        StaringCheck();
        TurnCheck();
    }

    //시야각 기록용 함수
    private void StaringCheck()
    {
        Vector3 targetDirection = _player.transform.position - transform.position;
        _angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
        print(_angleToPlayer);
    }
    //각도 체크 및 뒤돌기 확인 함수
    private void TurnCheck()
    {
        if (!_isTurning && _angleToPlayer >= _turnDegree && _angleToPlayer >= 0)
        {
            _isTurning = true;
            StartCoroutine(TurnAround());
        }
    }
    //뒷 모습 보일경우 호출
    IEnumerator TurnAround()
    {
        yield return new WaitForSeconds(.7f);
        print("TurnStart");
        while (true)
        {
            yield return null;
            //플레이어가 일정 시야각 이내에 들어오지 않았을 경우
            if (_angleToPlayer > _stareDegree)
            {
                transform.Rotate(Vector3.up * _rotationPow * Time.deltaTime);
                print("Turning");
            }
            /* else if (_angleToPlayer <= -_stareDegree && _angleToPlayer >= 0)
                 transform.Rotate(transform.right * _rotationPow);*/
            else
                break;
        }
        _isTurning = false;
        print("TurningEnd");
    }
}
