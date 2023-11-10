using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMob_1 : Mob
{
    [Header("산탄 공격이 퍼지는 정도. 5 권장")]
    [SerializeField] public float Spread;
    [Header("산탄 공격에서 생성될 총알 수")]
    [SerializeField] public int _AmountOfBullet;
    [Header("산탄 공격 총알 생성 주기. 0.05 권장")]
    [SerializeField] public float _SpreadCooltime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    protected override void FireBullet()
    {
        //base.FireBullet();
        StartCoroutine(FireBulletCoroutine());
    }
    IEnumerator FireBulletCoroutine()
    {
        for (int i = 0; i < _AmountOfBullet; i++)
        {
            GameObject copy = Instantiate(_bulletPrefab.gameObject, transform.position, transform.rotation);
            copy.GetComponent<EnemyProjectile>().SetTarget(_player.transform.position);
            yield return new WaitForSeconds(_SpreadCooltime);
        }
        StartCoroutine(CoolDown());
    }
}
