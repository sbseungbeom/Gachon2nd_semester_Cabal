using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public int HP;

    public virtual void Damage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            OnDeath();
        }
    }

    protected abstract void OnDeath();
}
