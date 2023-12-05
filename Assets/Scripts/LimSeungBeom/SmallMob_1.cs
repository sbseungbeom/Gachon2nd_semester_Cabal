using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SmallMob_1 : MonoBehaviour
{

    [SerializeField] int Direction = -1;

    [SerializeField] float MoveDistance;
    [SerializeField] float MinMoveDistance;
    [SerializeField] float MaxMoveDistance;

    [SerializeField] float MoveSpeed;
    [SerializeField] float MoveWaitTime;
    [SerializeField] float MinMoveWaitTime;
    [SerializeField] float MaxMoveWaitTime;

    float AttackWaitTime;
    [SerializeField] float MaxAttackWaitTime;
    [SerializeField] float MiNAttackWaitTime;

    [Header("산탄 공격이 퍼지는 정도. 5 권장")]
    [SerializeField] public float Spread;
    [Header("산탄 공격에서 생성될 총알 수")]
    [SerializeField] public int _AmountOfBullet;
    [Header("산탄 공격 총알 생성 주기. 0.05 권장")]
    [SerializeField] public float _SpreadCooltime;

    GameObject Player;
    [SerializeField] GameObject Projectile;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        StartCoroutine(MobMove());
        StartCoroutine(Attack());

    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1 * Direction * MoveDistance, transform.position.y, transform.position.z), Time.deltaTime * MoveSpeed);
    }
    IEnumerator MobMove()
    {
        //------------------ 방향 제어--------------
        Vector3 viewpos = Camera.main.WorldToViewportPoint(this.gameObject.transform.position); // 카메라 왼쪽 밖으로 나와있는지 확인
        if (viewpos.x <= 0) { Direction = 1; }
        if (viewpos.x >= 1) { Direction = -1; }
        if (0 < viewpos.x && viewpos.x < 1)
        {
            Direction = Random.Range(-1, 1);
            if (Direction == 0) Direction = 1;
        }

        MoveDistance = Random.Range(MinMoveDistance, MaxMoveDistance + 1); // 이동 거리
        MoveWaitTime = Random.Range(MinMoveWaitTime, MaxMoveWaitTime + 1); // 이동 후 다음이동까지 대기시간
        Direction = Random.Range(-1, 1);
        if (Direction == 0) Direction = 1;


        yield return new WaitForSeconds(MoveWaitTime);                          //전부 기다렸으면 다음 이동 시작
        StartCoroutine(MobMove());
    }

    IEnumerator Attack()
    {
        AttackWaitTime = Random.Range(MiNAttackWaitTime,MaxAttackWaitTime + 1);
        Vector3 SettedPlayerPosition = Player.transform.position;

        for(int i = 0; i < _AmountOfBullet;  i++)
        {
            GameObject bullet = Instantiate(Projectile, transform.position, Quaternion.identity);
            bullet.transform.LookAt(new Vector3((SettedPlayerPosition.x - Spread) + (i * (Spread * 2 / _AmountOfBullet)), SettedPlayerPosition.y, SettedPlayerPosition.z));
            yield return new WaitForSeconds(_SpreadCooltime);
        }



        yield return new WaitForSeconds(AttackWaitTime);
        StartCoroutine (Attack());
    }

}
