using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int initHP = 4;
    [SerializeField] private ElementType _elementType;

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

    public void Damage(int damage, ElementType elementType)
    {
        if(Player.IsDominentTo(elementType, _elementType))
        {
            Damage(damage * 2);
        }
        else
        {
            Damage(damage);
        }
    }

    protected abstract void OnDeath();
}
