using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SYODFist : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //플레이어 데미지 주는 코드.
            this.gameObject.SetActive(false);
            Debug.Log("플레이어 피격!");
        }
    }
}
