using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class WaterGolem : Enemy
{
    GameObject Player;
    GameObject WarningRotator;
    GameObject Warning;
    bool IsAiming;
    Vector3 SettedPlayerPosition;

    [Header("조준 시간")]
    [SerializeField] float AimingTime;

    [Header("총알 수")]
    [SerializeField] int AmoutOfBullet;

    [Header("총알 연사 속도 (초)")]
    [SerializeField] float Rapid;

    [Header("조준 완료 후 총알 발사까지 유예 시간 (초)")]
    [SerializeField] float AttackWaitTime;
    

    void Start()
    {
        WarningRotator = transform.GetChild(0).gameObject;
        WarningRotator.SetActive(false);

        Player = GameManager.Instance.Player.gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (IsAiming)
        {
            WarningRotator.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y - 0.3f, Player.transform.position.z));
        }
        if(IsAiming == false)
        {
            WarningRotator.transform.LookAt(new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y - 0.3f, SettedPlayerPosition.z));
        }
    }
    protected override void Attack()
    {
        StartCoroutine(WaterGolemAttack());
    }

    IEnumerator WaterGolemAttack()
    {
        IsAiming = true;
        WarningRotator.SetActive(true);

        yield return new WaitForSeconds(AimingTime);
        IsAiming = false;
        SettedPlayerPosition = Player.transform.position;

        yield return new WaitForSeconds(AttackWaitTime);

        WarningRotator.SetActive(false);
        WarningRotator.transform.LookAt(new Vector3(SettedPlayerPosition.x, SettedPlayerPosition.y - 1, SettedPlayerPosition.z));

        for (int i =0; i < AmoutOfBullet; i++)
        {
            Projectile bullet = Instantiate(Data.projectile, transform.position, Quaternion.identity);

            bullet.Owner = this;
            bullet.transform.LookAt(SettedPlayerPosition);
            yield return new WaitForSeconds(Rapid);
        }


    }
}
