using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCollider : Entity
{
    BlackMagician _origin;
    protected override void OnDeath()
    {
        throw new System.NotImplementedException();
    }
    public override void Damage(int damage)
    {
        _origin.Damage(damage * 2);
    }
}
