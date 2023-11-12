using Infrastructure.Fabric;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class GameLevelInstaller:MonoInstaller
    {
        [SerializeField] private Game _game;
        
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private CameraTargeter _cameraTargeter;
        private IGameFactory _gameFactory;
        
        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
        public override void InstallBindings()
        {
            
            GameObject car=_gameFactory.CreatePlayer(_spawnPoint);
            _cameraTargeter.SetupTarget(car.transform);
            Container
                .Bind<CarMover>()
                .FromInstance(car.GetComponent<CarMover>());
            
            Container
                .Bind<Game>()
                .FromInstance(_game)
                .AsSingle();
            
            
        }
    }
}