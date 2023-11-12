using UI;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
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
}
