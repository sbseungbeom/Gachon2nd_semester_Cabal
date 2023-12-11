using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteMagicianNormalShot : Projectile
{
    private RoundaboutMovement _player;
    private int _mode;
    private float _count;
    [SerializeField] private float _chaseCount;
    [SerializeField] private float _waitCount;
    [SerializeField] private float _DesCount;
    // Start is called before the first frame update
    void Start()
    {
        IsEnemyProjectile = true;
        _player = FindObjectOfType<RoundaboutMovement>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        Movement();
    }
    private void Movement()
    {
        switch (_mode)
        {
            //플레이어 머리 위에서 추적
            case 0:
                if (_count < _chaseCount)
                {
                    _count += Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, new Vector3(_player.transform.position.x, _player.transform.position.y + Random.Range(10, 15), _player.transform.position.z), speed);
                }
                else
                {
                    _count = 0;
                    _mode++;
                }
                break;
            //멈추기
            case 1:
                if (_count < _waitCount)
                    _count += Time.deltaTime;
                else
                {
                    _count = 0;
                    _mode++;
                }
                break;
            //내려찍기
            case 2:
                if (_count < _DesCount)
                {
                    _count += Time.deltaTime;
                    transform.position += Time.deltaTime * Vector3.down * speed * 1.2f;
                }
                else
                    Destroy(gameObject);
                break;
        }
    }
}
