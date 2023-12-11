using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCollider : Entity
{
    [SerializeField] BlackMagician _origin;
    [SerializeField] bool _isBack;
    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
    public override void Damage(int damage)
    {
        if (_isBack)
            _origin.Damage(damage * 2);
        else
            _origin.Damage(damage);
    }
}
