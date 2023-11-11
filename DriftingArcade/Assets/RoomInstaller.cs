using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class RoomInstaller : MonoInstaller
{
    [SerializeField] private RoomMediator _roomMediator;
    public override void InstallBindings()
    {
        Container.Bind<RoomMediator>().FromInstance(_roomMediator);
    }
}
