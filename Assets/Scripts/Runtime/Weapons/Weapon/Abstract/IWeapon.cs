using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();
    void SetWeaponData();
    void PlayFireEffect();
    void ChangeActiveneesWeapon(bool value);
}
