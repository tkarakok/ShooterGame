using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface IMagazine
{
    void SetMagazineDatas(MagazineData magazineData);
    void DecreaseCurrentAmmoInMagazine();
    void Reload();
    void ChangeCanFire(bool param);
    bool CanFire();
}
