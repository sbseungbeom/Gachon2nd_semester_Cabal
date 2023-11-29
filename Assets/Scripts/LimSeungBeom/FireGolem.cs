using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolem : Enemy
{
    [SerializeField] float WarningDuration;    //경고 지속시간

    bool bAttackReady;
    bool bAttackSet;
    bool bAttackStart;
    bool bReturn;
    GameObject Player;
    [SerializeField] GameObject Warning;

    Vector3 SavedEnemyPosition;
    Vector3 SavedPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.Player.gameObject;
        Warning = transform.GetChild(0).gameObject;
        Warning.SetActive(false);

        bAttackReady = false;
        bAttackSet = false;
        bAttackStart = false;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(bAttackReady)
        {
            Rope.position = Vector3.MoveTowards(Rope.position, new Vector3(Rope.position.x, Rope.position.y + 15, Rope.position.z), 25 * Time.deltaTime);

            Warning.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 10, Player.transform.position.z);

            Warning.transform.eulerAngles = new Vector3(0, 0, 0);

        }
        if(bAttackSet)
        {
            Rope.position = new Vector3(SavedPlayerPosition.x,SavedPlayerPosition.y + 40 ,SavedPlayerPosition.z);

            Warning.transform.position = new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y + 10, SavedPlayerPosition.z);
        }
        if(bAttackStart)
        {
            Rope.position = Vector3.MoveTowards(Rope.position, new Vector3(Rope.position.x, Rope.position.y - 3, Rope.position.z), 35 * Time.deltaTime);
        }
        if(bReturn)
        {
            Rope.position = Vector3.MoveTowards(Rope.position, SavedEnemyPosition,50 * Time.deltaTime);
        }

    }
    protected override void Attack()
    {
        StartCoroutine(FireGolemAttack());
    }
    IEnumerator FireGolemAttack()
    {
        Debug.Log("공격");
        StartCoroutine(Stop(WarningDuration + 10));
        //위로 쓕! 하고 올라갔다가 몇 초 후에 플레이어 위로 떨어짐. 공격이 플레이어에게 유도됨.
        SavedEnemyPosition = new Vector3(Rope.position.x,Rope.position.y,Rope.position.z);
        bAttackReady = true;
        Warning.SetActive(true);
        yield return new WaitForSeconds(WarningDuration / 2);
        bAttackReady = false;
        yield return new WaitForSeconds(WarningDuration / 2); //경고 시간 끝 , 공격 위치 고정
        SavedPlayerPosition = Player.transform.position;
        bAttackSet = true;
        
        yield return new WaitForSeconds(3); //공격 위치 고정 후 3초후에 낙하.
        Warning.SetActive(false);
        bAttackSet = false;
        bAttackStart = true;
        yield return new WaitForSeconds(2);
        bAttackStart = false;
        bReturn = true;
        yield return new WaitForSeconds(2);
        bReturn = false;
    }
}
