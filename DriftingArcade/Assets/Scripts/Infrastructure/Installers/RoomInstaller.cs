using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomInstaller : MonoInstaller
{
    [SerializeField] private RoomMediator _roomMediator;
    [SerializeField] private CarCustomizationView _carCustomization;
    public override void InstallBindings()
    {
        Container.Bind<RoomMediator>().FromInstance(_roomMediator);
        Container.Bind<CarCustomizationView>().FromInstance(_carCustomization);
    }
}
