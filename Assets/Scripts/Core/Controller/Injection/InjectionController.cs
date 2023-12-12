using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;


public class InjectionController : MonoInstaller, IInjectionController
{
    [SerializeField] private CrosshairController _crosshairController;
    public override void InstallBindings()
    {
        Container.Bind<CrosshairController>().FromComponentInHierarchy(_crosshairController).AsSingle();
    }
}