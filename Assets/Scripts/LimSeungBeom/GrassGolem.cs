using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GrassGolem : Enemy
{
    [Header("산탄 공격이 퍼지는 정도. 5 권장")]
    [SerializeField] public float Spread;
    [Header("산탄 공격에서 생성될 총알 수")]
    [SerializeField] public int _AmountOfBullet;
    [Header("산탄 공격 총알 생성 주기. 0.05 권장")]
    [SerializeField] public float _SpreadCooltime;

    GameObject Player;

    void Start()
    {
        Player = GameManager.Instance.Player.gameObject;

        
    }

    protected override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }
    IEnumerator AttackCoroutine()
    {
        Vector3 SettedPlayerPosition = Player.transform.position;

        for(int i = 0; i < _AmountOfBullet;  i++)
        {
            Projectile bullet = Instantiate(Data.projectile, transform.position, Quaternion.identity);
            bullet.IsEnemyProjectile = true;
            bullet.transform.LookAt(new Vector3((SettedPlayerPosition.x - Spread) + (i * (Spread * 2 / _AmountOfBullet)), SettedPlayerPosition.y, SettedPlayerPosition.z));
            yield return new WaitForSeconds(_SpreadCooltime);
        }
    }

}
