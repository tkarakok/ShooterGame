using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletCollisionController))]
public class Bullet : PoolObject, IBullet
{
    public int Damage { get; private set; }
    
    public void SetDamage(int damage)
    {
        Damage = damage;
    }
}
