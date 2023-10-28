using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SmallMob_1 : MonoBehaviour
{

    [SerializeField] public float SmallMob_1_Hp = 10;


    [SerializeField] private float _shootCoolDownMin, _shootCoolDownMax;
    [SerializeField] private float _dirChangeMinTime, _dirChangeMaxTime;
    [SerializeField] private float _moveSpeed;

    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] public GameObject _player;


    [Header("산탄 공격이 퍼지는 정도. 5 권장")]
    [SerializeField] public float Spread;
    [Header("산탄 공격에서 생성될 총알 수")]
    [SerializeField] public int _AmountOfBullet;
    [Header("산탄 공격 총알 생성 주기. 0.05 권장")]
    [SerializeField] public float _SpreadCooltime;

    private int _dir = 1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CoolDown());
        StartCoroutine(DirectionChange());
        //_player = GameObject.FindGameObjectWithTag("Player");
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        transform.Translate(new Vector2(_moveSpeed * _dir * Time.deltaTime, 0));
    }
    IEnumerator DirectionChange()
    {
        yield return new WaitForSeconds(Random.Range(_dirChangeMinTime,_dirChangeMaxTime + .1f));
        int imsi = _dir * -1;
        _dir = 0;
        yield return new WaitForSeconds(Random.Range(_dirChangeMinTime, _dirChangeMaxTime + .1f));
        _dir = imsi;
        StartCoroutine(DirectionChange());
    }

    public void CheckCamIn()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        //만약 적 오브젝트의 크기 문제로 버그 발생시 스프라이트 랜더러의 bounds 값을 받아오는 코드로 교정
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            StartCoroutine(FireBullet());
        else
            StartCoroutine(CoolDown());
    }
    IEnumerator FireBullet()
    {
        for(int i = 0; i < _AmountOfBullet; i++)
        {
            GameObject copy = Instantiate(_bulletPrefab, transform.position, transform.rotation);
            copy.transform.LookAt(new Vector3(_player.transform.position.x - Spread + i * (Spread * 2 / _AmountOfBullet) ,_player.transform.position.y,_player.transform.position.z));
            yield return new WaitForSeconds(_SpreadCooltime);
        }
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(Random.Range(_shootCoolDownMin, _shootCoolDownMax));
        CheckCamIn();
    }
}
