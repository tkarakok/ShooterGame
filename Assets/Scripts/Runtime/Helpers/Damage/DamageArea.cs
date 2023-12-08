using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour, IDamageArea
{
    protected IDamagable _damagable;

    public virtual void Start()
    {
        _damagable = GetComponentInParent<IDamagable>();
    }

    public virtual void TakeDamage(int damage)
    {
        _damagable.TakeDamage(damage);
    }
}
