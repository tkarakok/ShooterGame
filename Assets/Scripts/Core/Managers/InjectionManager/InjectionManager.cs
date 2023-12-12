using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InjectionController))]
public class InjectionManager : Singleton<InjectionManager>
{
    public InjectionController InjectionController { get; private set; }

    private void Start()
    {
        InjectionController = GetComponent<InjectionController>();
    }
}
