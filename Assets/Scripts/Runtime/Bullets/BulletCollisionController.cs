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
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Hit"))
        {
            var damageArea = collision.gameObject.GetComponent<IDamagable>();
            _bullet.ResetVelocity();
            damageArea.TakeDamage(_bullet.Damage);
            var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Blood).Data.GetPoolObject(false);
            var particle = effect.GetComponent<Particle>();
            particle.PlayEffect(collision.contacts[0].point);
            _bullet.ResetObject();
        }
        else if (collision.transform.TryGetComponent(out IDamageArea damageArea))
        {
            
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.transform.TryGetComponent(out IDamageArea damageArea))
        // {
        //     _bullet.ResetVelocity();
        //     damageArea.TakeDamage(_bullet.Damage);
        //     var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Blood).Data.GetPoolObject(false);
        //     var particle = effect.GetComponent<Particle>();
        //     particle.PlayEffect(other.transform.position);
        //     _bullet.ResetObject();
        // }
        
    }

}
