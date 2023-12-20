using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject Player;
    Player PlayerScript;

    GameObject project;
    GameObject Hiteffect;
    private void Awake()
    {
        //Player = GameObject.FindWithTag("Player");    //실제 보스에 적용 시 이 문을 삭제할 것.

        project = transform.GetChild(0).gameObject;
        Hiteffect = transform.GetChild(1).gameObject;

        Player = GameManager.Instance.Player.gameObject;
        PlayerScript = Player.GetComponent<Player>();

    }
    private void OnEnable()
    {
        //transform.LookAt(Player.transform.position);
        Hiteffect.SetActive(false);
        project.SetActive(true);
    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * this.transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject == Player)
        {
            PlayerScript.Damage(1);
            project.SetActive(false);
            Hiteffect.SetActive(true);
            speed = 0;
        }
        

    }
}