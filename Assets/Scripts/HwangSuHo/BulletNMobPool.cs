using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNMobPool : MonoBehaviour
{
    [SerializeField] List<Projectile> _projectilePool;
    int _projectileCount;
    int _projectileFullCount;
    [SerializeField] int _projectileFieldCount;
    [SerializeField] List<Mob> _mobPool;
    int _mobCount;
    int _mobFullCount;
    [SerializeField] int _mobFieldCount;

    private void Start()
    {

    }
    //몹이나 프로젝타일을 받아서 골라 풀에 추가?
    public void AddPool()
    {

    }
    public void Generate()
    {

    }
    //몹이나 프로젝타일을 받아서 골라 풀에 추가?
    public void ReturnPool()
    {

    }
}
