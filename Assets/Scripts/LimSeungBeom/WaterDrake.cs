using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrake : Enemy
{
    GameObject Player;

    GameObject Warn;
    GameObject Laser;

    bool Aiming;
    bool StartAttack;
    Vector3 SavedPlayerPosition;

    [Header("조준 시간")]
    [SerializeField] float AimingTime;
    [Header("조준 완료 후 레이저 발사까지 유예 시간")]
    [SerializeField] float AttackWaitTime;
    [Header("레이저 유지 시간")]
    [SerializeField] float AttackDuration;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.Player.gameObject;
        Warn = transform.GetChild(0).gameObject;
        Laser = transform.GetChild(1).gameObject;

        Warn.SetActive(false);
        Laser.SetActive(false);

        Aiming = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if(Aiming)
        {
            Warn.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z));
        }

    }
    protected override void Attack()
    {
        StartCoroutine(WaterDrakeAttack());
    }

    IEnumerator WaterDrakeAttack()
    {
        StartCoroutine(Stop(AimingTime + AttackWaitTime + AttackDuration));

        Warn.SetActive(true);
        Aiming = true;
        yield return new WaitForSeconds(AimingTime);
        Aiming = false;
        SavedPlayerPosition = Player.transform.position;
        Warn.transform.LookAt(new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y - 0.5f, SavedPlayerPosition.z));
        Laser.transform.LookAt(new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y, SavedPlayerPosition.z));
        yield return new WaitForSeconds(AttackWaitTime);
        Laser.SetActive(true);
        yield return new WaitForSeconds(AttackDuration);
        Laser.SetActive(false);
        Warn.SetActive(false);

    }
}
