using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponChangeController
{
    void WeaponPanelAction();
    void OpenWeaponChangePanel();
    void CloseWeaponChangePanel();
    void ChangeWeapon(Weapon weapon);
}
