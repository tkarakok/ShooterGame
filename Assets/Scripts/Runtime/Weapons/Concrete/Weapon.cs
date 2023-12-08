using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public WeaponData WeaponData;
    protected ParticleSystem _fireEffect;
    public int Damage { get; private set; }
    public int ReloadDuration { get; private set; }

    public virtual void Start()
    {
        _fireEffect = GetComponentInChildren<ParticleSystem>();
        SetWeaponData();
    }

    public virtual void Attack()
    {
        
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