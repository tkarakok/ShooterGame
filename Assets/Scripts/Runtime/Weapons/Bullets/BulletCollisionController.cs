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
            ParticleManager.Instance.ParticleController.SetParticleAndPlay(collision.contacts[0].point, PoolType.Hit);
            _bullet.ResetObject();
        }
        else if(collision.gameObject.TryGetComponent(out IDamagable damagable))
        {
            _bullet.ResetVelocity();
            damagable.TakeDamage(_bullet.Damage);
            ParticleManager.Instance.ParticleController.SetParticleAndPlay(collision.contacts[0].point, PoolType.Blood);
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
