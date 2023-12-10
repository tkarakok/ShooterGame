using System.Collections;
using System.Collections.Generic;
using Core.Utilities.Results;
using UnityEngine;

public interface ICharacterAttack
{
    void GetAllWeapons();
    Result ChangeActiveWeapon(Weapon newWeapon);
    void Attack(IWeapon weapon);
}
