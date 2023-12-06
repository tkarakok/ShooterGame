using System;
using UnityEngine;

public class Pistol : Weapon, IPistol
{
    private Transform _firePoint;

    private void Awake()
    {
        _firePoint = GetComponentInChildren<FirePoint>().transform;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Attack()
    {
        base.Attack();
        Transform _bulletTransform = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Bullet).Data
            .GetPoolObject().transform;

        _bulletTransform.position = _firePoint.position;
        
        Rigidbody _bulletRb = _bulletTransform.GetComponent<Rigidbody>();
        
        _bulletTransform.GetComponent<IBullet>().SetDamage(Damage);

        Vector3 dir = (GameManager.Instance.CrossHair.position - _firePoint.position).normalized;

        _bulletRb.velocity = dir * 100;

    }
}