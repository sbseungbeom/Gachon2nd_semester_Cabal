using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLaser1 : MonoBehaviour
{
    GameObject Player;
    GameObject Laser;
    Transform Aimpoint;
    Transform SavedPlayerPosition;
    bool LaserOn;
    float ex;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Laser.transform.LookAt(Aimpoint);
        if (LaserOn)
        {
            Laser.SetActive(true);
            Aimpoint = Vector3.Lerp(, new Vector3(SavedPlayerPosition.x + 5, 0, SavedPlayerPosition.z), eX);
            eX += Time.deltaTime * 0.35f;
            Debug.Log("드레이크 공격");
        }
        if (!LaserOn)
        {
            Laser.SetActive(false);
            eX = 0;
            Debug.Log("드레이크 공격 끝");
        }
        */
    }

    IEnumerator BossLaser1Attack()
    {
        LaserOn = true;
        yield return new WaitForSeconds(1);
    }
}
