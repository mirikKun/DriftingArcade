using DefaultNamespace;
using UnityEngine;
using Zenject;

public class UiInstaller : MonoInstaller
{
    public SteerInput _steerInput;
    public override void InstallBindings()
    {
        Container
            .Bind<SteerInput>()
            .FromInstance(_steerInput)
            .AsSingle();
    }
}
