using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYODFist : MonoBehaviour
{
    [SerializeField] float speed;
    GameObject Player;
    Player PlayerScript;

    private void Awake()
    {
        //Player = GameObject.FindWithTag("Player");    //실제 보스에 적용 시 이 문을 삭제할 것.

        
        Player = GameManager.Instance.Player.gameObject;
        PlayerScript = Player.GetComponent<Player>();
        
    }
    private void OnEnable()
    {
        //transform.LookAt(Player.transform.position);
    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript.Damage(1);
            this.gameObject.SetActive(false);
        }
    }
}
