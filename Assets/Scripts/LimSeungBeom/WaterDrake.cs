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
        StartCoroutine(Stop(10));

        Warn.SetActive(true);
        Aiming = true;

        yield return new WaitForSeconds(3);

        Aiming = false;

        Laser.SetActive(true);

        SavedPlayerPosition = Player.transform.position;
        Warn.transform.LookAt(new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y - 0.5f, SavedPlayerPosition.z));
        Laser.transform.LookAt(new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y, SavedPlayerPosition.z));

        yield return new WaitForSeconds(2);
        Laser.SetActive(false);
        Warn.SetActive(false);

    }
}
