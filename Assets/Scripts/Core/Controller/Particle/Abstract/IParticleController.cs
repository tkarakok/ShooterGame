using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IParticleController
{
    void SetParticleAndPlay(Vector3 pos, PoolType poolType);
}
