using System;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public WeaponData WeaponData;

    public int Damage { get; private set; }
    public int ReloadDuration { get; private set; }

    public virtual void Start()
    {
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

}