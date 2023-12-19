using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDrake : Enemy
{

    public float laserDelay = 5;

    GameObject Player;
    GameObject Laser;
    [SerializeField] GameObject AttackWarning; //공격 전 경고표시
    [SerializeField] GameObject ExplosionAttack;         //공격 파티클

    GameObject DRAttack;
    GameObject DRAttackWarning;

    Player ps;


    Vector3 SavedPlayerPosition;

    float eX;
    bool LaserOn;
    Vector3 Aimpoint;

    private Queue <GameObject> AWQueue = new Queue <GameObject>();
    private Queue<GameObject> AQueue = new Queue<GameObject>();
   
    void Start()
    {
        Player = GameManager.Instance.Player.gameObject;
        ps = Player.GetComponent<Player>();
        Laser= transform.GetChild(0).gameObject;
        Laser.SetActive(false);

        for(int i = 0;i < 5;i++)
        {
            GameObject DRAttack = Instantiate(ExplosionAttack);
            GameObject DRAttackWarning = Instantiate(AttackWarning);

            DRAttack.SetActive(false);
            DRAttackWarning.SetActive(false);

            AWQueue.Enqueue(DRAttackWarning);
            AQueue.Enqueue(DRAttack);
        }

    }

    
    protected override void Update()
    {
        base.Update();
        Laser.transform.LookAt(Aimpoint);
        if(LaserOn)
        {
            Laser.SetActive(true);
            Aimpoint = Vector3.Lerp(
                new Vector3(SavedPlayerPosition.x - 5, SavedPlayerPosition.y - 0.5f, SavedPlayerPosition.z), 
                new Vector3(SavedPlayerPosition.x + 5, SavedPlayerPosition.y - 0.5f, SavedPlayerPosition.z), 
                eX);
            
            eX += Time.deltaTime * 0.35f;
            Debug.Log("드레이크 공격");
        }
        if(!LaserOn)
        {
            Laser.SetActive(false);
            eX = 0;
            Debug.Log("드레이크 공격 끝");
        }
    }
    protected override void Attack()
    {
        StartCoroutine(AttackCoroutine());
    }
    IEnumerator AttackCoroutine()
    {
        StartCoroutine(Stop(laserDelay));
        SavedPlayerPosition = Player.transform.position;
        LaserOn = true;
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ActiveAW(-3f));
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ActiveAW(-1.5f));
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ActiveAW(0));
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ActiveAW(1.5f));
        yield return new WaitForSeconds(0.6f);
        StartCoroutine(ActiveAW(3f));
        /*
        for (int i = 0; i < 5; i++)
        {
            b += 2.5f * i;
            StartCoroutine(ActiveAW(b));
            Debug.Log(b);
            yield return new WaitForSeconds(0.6f);
            b = -5;
        }              // 3초동안 5개 생성.
        */
        yield return new WaitForSeconds(1);
        LaserOn = false;
        yield return new WaitForSeconds(1);
        StartCoroutine(ActiveAttack(-3f));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(ActiveAttack(-1.5f));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(ActiveAttack(0));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(ActiveAttack(1.5f));
        yield return new WaitForSeconds(0.4f);
        StartCoroutine(ActiveAttack(3f));
        /*
        for(int i = 0; i < 5; i++)
        {
            b += 2.5f * i;
            StartCoroutine(ActiveAttack(b));
            yield return new WaitForSeconds(0.4f);
            b = -5;
        }
        */
    }
    IEnumerator ActiveAW(float a)
    {
        GameObject aw = AWQueue.Dequeue().gameObject;
        aw.SetActive(true);
        aw.transform.position = new Vector3(SavedPlayerPosition.x + a, 0, SavedPlayerPosition.z + 1);
        AWQueue.Enqueue(aw);
        yield return new WaitForSeconds(5);
        aw.SetActive(false);
    }
    IEnumerator ActiveAttack(float a)
    {
        GameObject Attack = AQueue.Dequeue().gameObject;
        Attack.SetActive(true);
        Attack.transform.position = new Vector3(SavedPlayerPosition.x + a, 0, SavedPlayerPosition.z + 1);
        Collider[] colliders = Physics.OverlapSphere(new Vector3(SavedPlayerPosition.x + a, 1, SavedPlayerPosition.z), 2);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == Player)
            {
                ps.Damage(1);
            }
        }


        AQueue.Enqueue(Attack);
        yield return new WaitForSeconds(2);
        Array.Clear(colliders, 0, colliders.Length);
        Attack.SetActive(false);
    }

}
