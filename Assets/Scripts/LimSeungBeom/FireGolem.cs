using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolem : Enemy
{

    GameObject Player;
    [SerializeField] GameObject Warning;

    [SerializeField] Sprite Jump;
    [SerializeField] Sprite Fall;
    [SerializeField] Sprite Idle;

    [SerializeField] Sprite[] sprites = new Sprite[3];

    SpriteRenderer spriter;
    Animator anim;

    bool bAttackReady;
    bool bAttackStart;
    bool bReturn;
    Vector3 SavedEnemyPosition;
    Vector3 SavedPlayerPosition;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameManager.Instance.Player.gameObject;
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Warning = transform.GetChild(0).gameObject;
        Warning.SetActive(false);
        
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        if (bAttackReady )
        {
            Rope.position = Vector3.MoveTowards(Rope.position, new Vector3(SavedEnemyPosition.x,SavedEnemyPosition.y + 20,SavedEnemyPosition.z), Time.deltaTime * 70);

            spriter.sprite = sprites[0];
        }
        if(bAttackStart )
        {
            Rope.position = Vector3.MoveTowards(Rope.position, new Vector3(SavedPlayerPosition.x,SavedPlayerPosition.y - 20,SavedPlayerPosition.z), Time.deltaTime * 50);
            spriter.sprite = sprites[1];
        }
        if(bReturn)
        {
            Rope.position = Vector3.MoveTowards(Rope.position, new Vector3(SavedEnemyPosition.x, SavedEnemyPosition.y, SavedEnemyPosition.z), Time.deltaTime * 30);
            spriter.sprite = sprites[2];
        }

        Warning.transform.position = new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y + 10, SavedPlayerPosition.z);

    }
    protected override void Attack()
    {
        StartCoroutine(FireGolemAttack());
    }
    IEnumerator FireGolemAttack()
    {
        StartCoroutine(Stop(10));

        SavedEnemyPosition = new Vector3(Rope.position.x,Rope.position.y,Rope.position.z);
        SavedPlayerPosition = Player.transform.position;

        anim.SetBool("AttackReady", true);

        yield return new WaitForSeconds(2);
        anim.SetBool("AttackReady", false);

        //spriter.sprite = sprites[0];
        bAttackReady = true;


        yield return new WaitForSeconds(1);
        //spriter.sprite = sprites[1];

        Warning.SetActive(true);
        Rope.position = new Vector3(SavedPlayerPosition.x, SavedPlayerPosition.y + 50, SavedPlayerPosition.z + 0.5f);
        bAttackReady = false;


        yield return new WaitForSeconds(2);
        Warning.SetActive(false);
        bAttackStart = true;


        yield return new WaitForSeconds(1);
        //spriter.sprite = sprites[2];

        bAttackStart = false;
        bReturn = true;


        yield return new WaitForSeconds(3);
        bReturn = false;

    }
}
