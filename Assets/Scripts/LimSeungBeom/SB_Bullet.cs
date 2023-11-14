using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("Рћ ИэСп");
        }
    }
}
