using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    //public int HP { get => _hp; set => _hp; }
    [SerializeField] protected int _hp;

    [SerializeField] protected float _shootCoolDownMin, _shootCoolDownMax;
    [SerializeField] protected float _dirChangeMinTime, _dirChangeMaxTime;
    [SerializeField] protected float _moveSpeed;
    protected int _dir;
    [SerializeField] protected EnemyProjectile _bulletPrefab;
    [SerializeField] protected GameObject _player;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        StartCoroutine(CoolDown());
        StartCoroutine(DirectionSet());
        Vector3 viewPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (viewPos.x <= .5f)
            _dir = 1;
        else
            _dir = -1;
        //_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void FixedUpdate()
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
    protected virtual void FireBullet()
    {
        EnemyProjectile copy = Instantiate(_bulletPrefab, transform.position, transform.rotation);
        copy.SetTarget(_player.transform.position);
        StartCoroutine(CoolDown());
    }
    protected virtual IEnumerator CoolDown()
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
