using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public WeaponData WeaponData;
    
    protected Transform _firePoint;
    protected ParticleSystem _fireEffect;
    protected IMagazine _magazine;
    
    public int Damage { get; private set; }
    public int ReloadDuration { get; private set; }

    public virtual void Start()
    {
        _fireEffect = GetComponentInChildren<ParticleSystem>();
        _firePoint = GetComponentInChildren<FirePoint>().transform;
        _magazine = GetComponentInChildren<IMagazine>();
        _magazine.SetMagazineDatas(WeaponData.MagazineData);
        SetWeaponData();
    }

    public virtual void Attack()
    {
        if (!_magazine.CanFire()) return;
        Transform _bulletTransform = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Bullet).Data
            .GetPoolObject(false).transform;

        _bulletTransform.position = _firePoint.position;
        _bulletTransform.gameObject.SetActive(true);
        Rigidbody _bulletRb = _bulletTransform.GetComponent<Rigidbody>();
        
        _bulletTransform.GetComponent<IBullet>().SetDamage(Damage);
        _magazine.DecreaseCurrentAmmoInMagazine();
        
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

    public void SetWeaponData()
    {
        Damage = WeaponData.Damage;
        ReloadDuration = WeaponData.ReloadDuration;
    }

    public void PlayFireEffect()
    {
        _fireEffect.Stop();
        _fireEffect.Play();
    }

    
}