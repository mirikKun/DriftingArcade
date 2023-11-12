using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace UI
{
    public class UiInstaller : MonoInstaller
    {
        [SerializeField] private SteerInput _steerInput;
        [SerializeField] private GameLevelMediator _mediator;
        public override void InstallBindings()
        {
            Container
                .Bind<SteerInput>()
                .FromInstance(_steerInput)
                .AsSingle();
            Container
                .Bind<GameLevelMediator>()
                .FromInstance(_mediator)
                .AsSingle();
        }
    }
}
