using System;
using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using DG.Tweening;
using UnityEngine;

public class Magazine : MonoBehaviour, IMagazine
{
    public int MagazineCapacity { get; private set; }
    public int CurrentAmmoInMagazine { get; private set; }
    public int TotalAmmo { get; private set; }
    public float ReloadDuration { get; private set; }
    public bool CanFire { get; private set; }
    
    public void SetMagazineDatas(MagazineData _magazineData)
    {
        MagazineCapacity = _magazineData.MagazineCapacity;
        ReloadDuration = _magazineData.ReloadDuration;
        TotalAmmo = 120;
        CurrentAmmoInMagazine = MagazineCapacity;
        ChangeCanFire(true);
    }

    public Result DecreaseCurrentAmmoInMagazine()
    {
        CurrentAmmoInMagazine -= 1;
        CurrentAmmoInMagazine = Mathf.Clamp(CurrentAmmoInMagazine, 0, MagazineCapacity);
        if (CurrentAmmoInMagazine <= 0 && TotalAmmo > 0)
        {
            Reload();
            return new SuccessResult("Success");
        }
        else
            return new ErrorResult("No Ammo");
    }

    public void Reload()
    {
        ChangeCanFire(false);
        DOVirtual.DelayedCall(ReloadDuration, () => ChangeCanFire(true)).OnComplete(()=>
        {
            TotalAmmo -= MagazineCapacity;
            CurrentAmmoInMagazine = MagazineCapacity;
        });
    }
    public void ChangeCanFire(bool param)
    {
        CanFire = param;
    }

    bool IMagazine.CanFire()
    {
        return CanFire;
    }
}
