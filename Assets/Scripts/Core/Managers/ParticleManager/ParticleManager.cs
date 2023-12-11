using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleController))]
public class ParticleManager : Singleton<ParticleManager>
{
    public ParticleController ParticleController { get; private set; }

    private void Awake()
    {
        ParticleController = GetComponent<ParticleController>();
    }
}
