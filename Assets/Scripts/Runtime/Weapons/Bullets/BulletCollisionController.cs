using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollisionController : MonoBehaviour
{
    private Bullet _bullet;

    private void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Env"))
        {
            _bullet.ResetVelocity();
            var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Hit).Data.GetPoolObject(false);
            var particle = effect.GetComponent<Particle>();
            particle.PlayEffect(collision.contacts[0].point);
            _bullet.ResetObject();
        }
        else if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            _bullet.ResetVelocity();
            damagable.TakeDamage(_bullet.Damage);
            var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Blood).Data.GetPoolObject(false);
            var particle = effect.GetComponent<Particle>();
            particle.PlayEffect(collision.contacts[0].point);
            _bullet.ResetObject();
        }
        else if (collision.gameObject.TryGetComponent(out IBarrel barrel))
        {
            _bullet.ResetVelocity();
            _bullet.ResetObject();
            barrel.SetExplosionPos(collision.transform.position);
            barrel.Interactable();
        }
    }


}
