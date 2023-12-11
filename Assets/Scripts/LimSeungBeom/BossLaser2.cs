using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class BossLaser2 : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject Player;

    //---------------------------------------------------------------- 아래만 필요함.
    [SerializeField] GameObject Laser2Warn;
    [SerializeField] GameObject Laser2Laser;
    Vector3 Laser2SavedPlayerPosition;
    bool Laser2AimingPlayer;
    [SerializeField] float Laser2Radius = 2;

    private void Awake()
    {
        Laser2Warn = Instantiate(Laser2Warn);
        Laser2Laser = Instantiate(Laser2Laser);
    }
    void Start()
    {

        Player = GameObject.FindWithTag("Player");
        //---------------------------------------------------------------- 아래만 필요함.
        Laser2Laser.SetActive(false);
        Laser2Warn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartLaserAttack();
        }

        if (Laser2AimingPlayer)
        {
            Laser2Warn.transform.position = Player.transform.position;
        }

        
    }
    public void StartLaserAttack()
    {
        StartCoroutine(LaserAttack2());
    }
    IEnumerator LaserAttack2()
    {
        Laser2Warn.SetActive(true);
        Laser2AimingPlayer = true;

        yield return new WaitForSeconds(5);
        Laser2AimingPlayer = false;
        Laser2SavedPlayerPosition = Player.transform.position;
        yield return new WaitForSeconds(0.5f);

        Laser2Laser.SetActive(true);
        Laser2Laser.transform.position = new Vector3(Laser2SavedPlayerPosition.x, Laser2SavedPlayerPosition.y - 0.7f, Laser2SavedPlayerPosition.z);

        //-------------------------------------------------플레이어 데미지 주는 부분
        Vector3 center = Laser2Laser.transform.position;

        Collider[] colliders = Physics.OverlapSphere(center, Laser2Radius);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == Player)
            {

            }
        }
        yield return new WaitForSeconds(3);

        Array.Clear(colliders, 0, colliders.Length);
        Laser2Warn.SetActive(false);
        Laser2Laser.SetActive(false);
    }
}
