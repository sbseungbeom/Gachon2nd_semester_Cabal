using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDrake : Enemy
{

    GameObject Player;
    [SerializeField] GameObject Projectile;
    GameObject[] Projectiles = new GameObject[15];
    [Header("공격이 x,y,z로 퍼지는 정도")]
    [SerializeField] float xoffset;
    [SerializeField] float yoffset;
    [SerializeField] float zoffset;
    [Header("공격 간 시간(연사속도) (초)")]
    [SerializeField] float rapid;
    int Index = 0;
    void Start()
    {
        for (int i = 0; i < Projectiles.Length; i++)
        {
            GameObject bullet = Instantiate(Projectile);
            Projectiles[i] = bullet;
            bullet.SetActive(false);
        }

        Player = GameManager.Instance.Player.gameObject;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (Index == Projectiles.Length) { Index = 0; }
    }

    protected override void Attack()
    {
        StartCoroutine(Stop(3));
        StartCoroutine(FireDrakeAtk());
    }

    IEnumerator ActivateFireDrakeAttack()
    {
        GameObject ActivatedProjectile = Projectiles[Index];
        ActivatedProjectile.SetActive(true);
        ActivatedProjectile.transform.position = new Vector3(this.transform.position.x,this.transform.position.y + 0.5f,this.transform.position.z + 1);

        float Xoffset = Random.Range(-xoffset, xoffset);
        float Yoffset = Random.Range(-yoffset, yoffset);
        float Zoffset = Random.Range(-zoffset, zoffset);
        ActivatedProjectile.transform.LookAt(new Vector3(Player.transform.position.x + Xoffset, Player.transform.position.y + Yoffset, Player.transform.position.z + Zoffset));
        yield return new WaitForSeconds(5);
        ActivatedProjectile.SetActive(false);
        ActivatedProjectile.transform.position = this.transform.position;
    }

    IEnumerator FireDrakeAtk()
    {

        for (int i = 0; i < Projectiles.Length; i++)
        {
            
            StartCoroutine(ActivateFireDrakeAttack());
            Index++;
            yield return new WaitForSeconds(rapid);
        }
    }

}
