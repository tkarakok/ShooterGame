using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour , IBarrel
{
    [SerializeField] private float _explosionRadius = 5;
    private Vector3 _explosionPos;
    public void Interactable()
    {
        var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Explosion).Data.GetPoolObject(false);
        var particle = effect.GetComponent<Particle>();
        particle.PlayEffect(_explosionPos);
        GetCharactersAndSetDamage();
    }

    public void SetExplosionPos(Vector3 pos)
    {
        _explosionPos = pos;
    }

    public void GetCharactersAndSetDamage()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, _explosionRadius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.TryGetComponent(out IDamagable damagable))
            {
                damagable.TakeDamage(20);   
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
