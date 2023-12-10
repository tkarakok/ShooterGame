using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActiveWeaponUIController 
{
    void SetAmmoValues(bool fontAnim = false);
    void SetTextColor();
    void SetActiveReload();
    void ChangeActiveWeaponImage();
}
