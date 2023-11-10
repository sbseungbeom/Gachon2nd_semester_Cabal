using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMob_2 : MonoBehaviour
{
    [SerializeField] int Direction = -1;

    [SerializeField] float MoveDistance;
    [SerializeField] float MinMoveDistance;
    [SerializeField] float MaxMoveDistance;

    [SerializeField] float MoveSpeed;
    [SerializeField] float MoveWaitTime;
    [SerializeField] float MinMoveWaitTime;
    [SerializeField] float MaxMoveWaitTime;


    [SerializeField] float WarningWaitTime;    //경고 지속시간
    [SerializeField] float AttackWaitTime;


    GameObject Player;
    [SerializeField] GameObject Projectile;
    GameObject WarningRotator;
    GameObject Warning;
    bool IsAiming;
    Vector3 SettedPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
        WarningRotator = transform.GetChild(0).gameObject;

        Player = GameObject.FindWithTag("Player");
        StartCoroutine(MobMove());
        StartCoroutine(Attack());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1 * Direction * MoveDistance, transform.position.y, transform.position.z), Time.deltaTime * MoveSpeed);

        if(IsAiming)
        {
            WarningRotator.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y - 1, Player.transform.position.z));
        }
        if(IsAiming == false)
        {
            WarningRotator.transform.LookAt(new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y - 1, SettedPlayerPosition.z));
        }
    }

    IEnumerator MobMove()
    {
        //------------------ 방향 제어--------------
        Vector3 viewpos = Camera.main.WorldToViewportPoint(this.gameObject.transform.position); // 카메라 왼쪽 밖으로 나와있는지 확인
        if (viewpos.x <= 0) { Direction = 1; }
        if (viewpos.x >= 1) { Direction = -1; }
        if(0 < viewpos.x && viewpos.x < 1)
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
        IsAiming = true;


        yield return new WaitForSeconds(3); //3초동안 준비 후 회전 중지.-------------------------------------------------

        IsAiming = false;
        SettedPlayerPosition = Player.transform.position;


        yield return new WaitForSeconds(2); // 2초후 전에 플레이어가 있던 위치로 발사.

        GameObject bullet = Instantiate(Projectile, transform.position, Quaternion.identity);
        bullet.transform.LookAt(SettedPlayerPosition);
        WarningRotator.transform.LookAt(new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y - 1, SettedPlayerPosition.z));

        yield return new WaitForSeconds(5);
        Debug.Log("공격 코루틴 실행");
        StartCoroutine (Attack());

    }
}
