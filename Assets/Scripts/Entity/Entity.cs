using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int initHP = 3;

    protected int hp, maxHp;
    public int HP { get => hp; }
    public int MaxHP { get => maxHp; }

    protected virtual void Awake()
    {
        hp = initHP;
        maxHp = hp;
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;
        if(hp <= 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();
}
