using System;
using UnityEngine;

[RequireComponent(typeof(Magazine))]
public abstract class Weapon : MonoBehaviour, IWeapon
{
    public WeaponData WeaponData;
    
    protected Transform _firePoint;
    protected ParticleSystem _fireEffect;
    public Magazine Magazine { get; protected set; }
    
    public int Damage { get; private set; }
    public int ReloadDuration { get; private set; }

    private bool _isActiveWeapon;
    
    public virtual void Awake()
    {
        _fireEffect = GetComponentInChildren<ParticleSystem>();
        _firePoint = GetComponentInChildren<FirePoint>().transform;
        Magazine = GetComponentInChildren<Magazine>();
        Magazine.SetMagazineDatas(WeaponData.MagazineData);
        SetWeaponData();
        
    }

    private void OnEnable()
    {
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.AddListener(PlayFireEffect);
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.AddListener(Magazine.DecreaseCurrentAmmoInMagazine);
    }

    private void OnDisable()
    {
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.RemoveListener(PlayFireEffect);
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.RemoveListener(Magazine.DecreaseCurrentAmmoInMagazine);
    }

    public virtual void Attack()
    {
        if (!Magazine.CanFire || !_isActiveWeapon) return;
        
        Transform _bulletTransform = ObjectPoolManager.Instance.OjectPoolController.GetPool(PoolType.Bullet).Data
            .GetPoolObject(false).transform;

        _bulletTransform.position = _firePoint.position;
        _bulletTransform.gameObject.SetActive(true);
        Rigidbody _bulletRb = _bulletTransform.GetComponent<Rigidbody>();
        
        _bulletTransform.GetComponent<IBullet>().SetDamage(Damage);
        
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); 
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

        // PlayFireEffect();
        // Magazine.DecreaseCurrentAmmoInMagazine();
        EventManager.Instance.EventController.GetEvent<FireEvent>().Data.Execute();
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

    public void ChangeActiveneesWeapon(bool value)
    {
        _isActiveWeapon = value;
    }
}