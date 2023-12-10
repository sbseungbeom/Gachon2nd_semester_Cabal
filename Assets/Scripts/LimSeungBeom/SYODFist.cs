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
        Player = GameObject.FindWithTag("Player");
        /*
        Player = GameManager.Instance.Player.gameObject;
        PlayerScript = Player.GetComponent<Player>();
        */
    }
    private void OnEnable()
    {
        transform.LookAt(Player.transform.position);
    }

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            //PlayerScript.HP -= 1;
            this.gameObject.SetActive(false);
        }
    }
}
