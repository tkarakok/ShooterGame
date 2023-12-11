using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour, IParticleController
{
    public void SetParticleAndPlay(Vector3 pos, PoolType poolType)
    {
        var effect = ObjectPoolManager.Instance.OjectPoolController.GetPool(poolType).Data.GetPoolObject(false);
        var particle = effect.GetComponent<Particle>();
        particle.PlayEffect(pos);
    }
}
