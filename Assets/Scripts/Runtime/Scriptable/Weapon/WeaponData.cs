using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class WeaponData : ScriptableObject
{
    public Sprite WeaponImage;
    public MagazineData MagazineData;
    public int Damage;
    public int ReloadDuration;
}
