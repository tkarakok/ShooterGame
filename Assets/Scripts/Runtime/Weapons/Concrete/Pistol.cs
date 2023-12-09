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
            .GetPoolObject(false).transform;

        _bulletTransform.position = _firePoint.position;
        _bulletTransform.gameObject.SetActive(true);
        Rigidbody _bulletRb = _bulletTransform.GetComponent<Rigidbody>();
        
        _bulletTransform.GetComponent<IBullet>().SetDamage(Damage);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // Ekranın ortasına ışın gönderme
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 999f))
        {
            if (hit.transform)
            {
                Vector3 dir =  (hit.point - _firePoint.position).normalized;
                _bulletRb.velocity = dir * 100;
            }
           
           
        }
        else
        {
            _bulletRb.velocity = _firePoint.transform.forward * 100;
        }
        
        PlayFireEffect();

    }

}