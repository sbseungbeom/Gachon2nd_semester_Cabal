using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolem : Enemy
{

    GameObject Player;

    [SerializeField] GameObject Warning;
    [SerializeField] GameObject Meteor;

    bool AttackAiming;
    
    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameManager.Instance.Player.gameObject;

        Warning = transform.GetChild(0).gameObject;
        Meteor = transform.GetChild(1).gameObject;
    }
    void Start()
    {
        Warning.SetActive(false);
        Meteor.SetActive(false);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if(AttackAiming)
        {
            Warning.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y - 0.7f,Player.transform.position.z);
        }

    }
    protected override void Attack()
    {
        StartCoroutine(FireGolemAttack());
    }
    IEnumerator FireGolemAttack()
    {
        

        Warning.SetActive(true);
        AttackAiming = true;
        yield return new WaitForSeconds(6);

        Meteor.SetActive(true);
        Meteor.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y - 0.5f, Player.transform.position.z);
        AttackAiming = false;

        yield return new WaitForSeconds(3);

        Warning.SetActive(false);
        Meteor.SetActive(false);


    }
}
