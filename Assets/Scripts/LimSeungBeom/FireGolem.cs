using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolem : MonoBehaviour
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

    [SerializeField] float WarningDuration;
    [SerializeField] float TopAttackWaitSpeed;
    [SerializeField] float UnjiSpeed;
    [SerializeField] float ReturnSpeed;

    bool TargetSet;
    bool TopAttack; 
    bool TopAttackStart;
    bool Return;
    GameObject Player;
    GameObject WarningRotator;
    GameObject Warning;

    Vector3 SettedPlayerPosition;
    Vector3 SavedEnemyPosition;
    // Start is called before the first frame update
    void Start()
    {

        WarningRotator = transform.GetChild(0).gameObject;
        WarningRotator.SetActive(false);

        Player = GameObject.FindWithTag("Player");
        StartCoroutine(MobMove());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(1 * Direction * MoveDistance, transform.position.y, transform.position.z), Time.deltaTime * MoveSpeed);

        if(TopAttack)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y + 10, SettedPlayerPosition.z), Time.deltaTime * TopAttackWaitSpeed);
        }
        if(TopAttackStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y - 10, SettedPlayerPosition.z), Time.deltaTime * UnjiSpeed);
        }
        if(Return)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(SavedEnemyPosition.x,SavedEnemyPosition.y,SavedEnemyPosition.z), Time.deltaTime * ReturnSpeed);
        }
        if(TargetSet)
        {
            WarningRotator.transform.position = new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y + 20, SettedPlayerPosition.z); ;
        }
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
        SettedPlayerPosition = Player.transform.position;
        StartCoroutine(Attack()); // 첫 스폰 시 이동만 하고 이동 후 공격 함수 실행.
    }
    IEnumerator Attack()
    {

        SavedEnemyPosition = this.gameObject.transform.position;

        WarningRotator.SetActive(true);
        TargetSet = true;
        TopAttack = true;
        WarningRotator.transform.LookAt(SettedPlayerPosition);

        yield return new WaitForSeconds(WarningDuration); //경고 시간.
        TopAttack= false;
        Debug.Log("이동 완료, 공격 시작");
        TopAttackStart = true;
        
        
        yield return new WaitForSeconds(1);
        TopAttackStart = false;
        Return = true;
        yield return new WaitForSeconds(2);
        TargetSet = false;
        Return = false;
        WarningRotator.SetActive(false);
        StartCoroutine(MobMove());


    }
}
