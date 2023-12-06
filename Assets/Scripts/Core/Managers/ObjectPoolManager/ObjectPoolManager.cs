using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ObjectPoolController))]
public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    public ObjectPoolController OjectPoolController { get; private set; }
    private void Awake()
    {
        OjectPoolController = GetComponent<ObjectPoolController>();
    }

    private void Start()
    {
        OjectPoolController.InitializePools();
    }
}
