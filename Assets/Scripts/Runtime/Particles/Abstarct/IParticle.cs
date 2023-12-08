using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParticle
{
    void SetPosition(Vector3 position);
    void PlayEffect(Vector3 position);
}
