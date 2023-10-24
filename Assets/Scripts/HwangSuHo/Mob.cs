using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    //public int HP { get => _hp; set => _hp; }
    [SerializeField] private int _hp;

    [SerializeField] private float _shootCoolDownMin, _shootCoolDownMax;
    [SerializeField] private float _dirChangeMinTime, _dirChangeMaxTime;
    [SerializeField] private float _moveSpeed;
    private int _dir;
    [SerializeField] EnemyProjectile _bulletPrefab;
    GameObject _player;

    // Start is called before the first frame update
    protected void Start()
    {
        StartCoroutine(CoolDown());
        StartCoroutine(DirectionSet());
        _dir = 1;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void FixedUpdate()
    {
        MoveSet();
    }

    public void MoveSet()
    {
        transform.Translate(new Vector2(_moveSpeed * _dir * Time.deltaTime, 0));
    }
    IEnumerator DirectionSet()
    {
        yield return new WaitForSeconds(Random.Range(_dirChangeMinTime, _dirChangeMaxTime + .1f));
        int imsi = _dir * -1;
        _dir = 0;
        yield return new WaitForSeconds(Random.Range(_dirChangeMinTime, _dirChangeMaxTime + .1f));
        _dir = imsi;
        StartCoroutine(DirectionSet());
    }



    public void CheckCamIn()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        //만약 적 오브젝트의 크기 문제로 버그 발생시 스프라이트 랜더러의 bounds 값을 받아오는 코드로 교정
        if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            FireBullet();
        else
            StartCoroutine(CoolDown());
    }
    protected void FireBullet()
    {
        EnemyProjectile copy = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        copy.SetTarget(_player.transform.position);
        StartCoroutine(CoolDown());
    }
    IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(Random.Range(_shootCoolDownMin, _shootCoolDownMax));
        CheckCamIn();
    }

    public void GetDamage(int damage)
    {
        _hp -= damage;
        if (_hp <= 0)
            Destroy(this.gameObject);
    }
}
