using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Particle : PoolObject, IParticle
{
    [SerializeField] private bool isStopActionCallback;
    private ParticleSystem _particleSystem;
    private ParticleSystem.MainModule _main;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        if (isStopActionCallback)
            _main.stopAction = ParticleSystemStopAction.Callback;
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
        if (isStopActionCallback)
            ResetObject();
    }

    private void OnParticleSystemStopped()
    {
        ResetObject();
    }
}
