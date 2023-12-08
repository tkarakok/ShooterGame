using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Particle : PoolObject, IParticle
{
    private ParticleSystem _particleSystem;

    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void PlayEffect(Vector3 position)
    {
        SetPosition(position);
        if(!gameObject.activeInHierarchy)
            gameObject.SetActive(true);
        _particleSystem.Stop();
        _particleSystem.Play();
        DOVirtual.DelayedCall(.2f, ResetObject);
    }
}
