using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Vector3 _targetSpot;
    private float _shotSpeed;
    // Start is called before the first frame update
    void Start()
    {
        SetSpeed(7);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fly();
    }

    public void SetTarget(Vector3 tar)
    {
        _targetSpot = tar;
        transform.LookAt(_targetSpot);
    }
    public void SetSpeed(float set)
    {
        _shotSpeed = set;
    }
    private void Fly()
    {
        //transform.Translate(/* _shotSpeed * Time.deltaTime*/);
        transform.position = Vector3.MoveTowards(transform.position, _targetSpot, _shotSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //플레이어 피해
            Destroy(this.gameObject);
        }
    }
}
