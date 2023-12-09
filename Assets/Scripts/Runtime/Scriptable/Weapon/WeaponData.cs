using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public MagazineData MagazineData;
    public int Damage;
    public int ReloadDuration;
}
