using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Drake : MonoBehaviour
{

    GameObject Player;
    Animator anim;

    GameObject Laser;
    [SerializeField] float Speed;
    Vector3 AimPoint;
    Vector3 SavedPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
        Laser= transform.GetChild(0).gameObject;
        Laser.SetActive(false);

        StartCoroutine(AttackCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))         //공격 시 실행
        {
            anim.SetBool("bIsAttack", true);
            Laser.transform.LookAt(AimPoint);
        }
        if (Input.GetKey(KeyCode.I))        //공격 중지 시 실행
        {
            Laser.SetActive(false);
            anim.SetBool("bIsAttack", false);
        }
        Laser.transform.LookAt(AimPoint);
        Laser.SetActive(true);
        Debug.Log(AimPoint);
        //AimPoint = Vector3.Lerp(new Vector3(SavedPlayerPosition.x - 10, SavedPlayerPosition.y - 1, SavedPlayerPosition.z), new Vector3(SavedPlayerPosition.x + 10, SavedPlayerPosition.y - 1, SavedPlayerPosition.z), Time.deltaTime * Speed);
        AimPoint = Vector3.Lerp(transform.position, Player.transform.position, Time.deltaTime * Speed);
    }


    IEnumerator AttackCoroutine()
    {
        SavedPlayerPosition = Player.transform.position;
        yield return new WaitForSeconds(1);
    }
}
