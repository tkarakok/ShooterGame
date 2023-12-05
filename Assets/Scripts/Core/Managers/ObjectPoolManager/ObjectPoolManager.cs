using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(ObjectPoolController))]
public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    private ObjectPoolController _objectPoolController;
    private void Awake()
    {
        _objectPoolController = GetComponent<ObjectPoolController>();
    }

    private void Start()
    {
        _objectPoolController.InitializePools();
    }
}
