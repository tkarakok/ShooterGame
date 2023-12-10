using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBarrel : IInteractable
{
    void SetExplosionPos(Vector3 pos);
    void GetCharactersAndSetDamage();
}
