using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using Zenject;
using AndroidInput = DefaultNamespace.AndroidInput;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IInput>().To<AndroidInput>().AsSingle();
    }
}
