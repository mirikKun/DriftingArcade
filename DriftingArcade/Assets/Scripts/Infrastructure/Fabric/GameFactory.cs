using Infrastructure.AssetManagement;
using Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace Infrastructure.Fabric
{
    public class GameFactory:IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgressService _persistentProgressService;
        private GameObject _playerGameObject;
        private readonly string _playerPath= "PlayerCar";
        private DiContainer _diContainer;
        [Inject]
        public GameFactory(DiContainer diContainer,IAssetProvider assets, IPersistentProgressService persistentProgressService)
        {
            _assets = assets;
            _persistentProgressService = persistentProgressService;
            _diContainer = diContainer;
        }
        public GameObject CreatePlayer(Transform at)
        {
            GameObject playerAsset=_assets.GetAsset(path: _playerPath);
            _playerGameObject=_diContainer.InstantiatePrefab(playerAsset, at.position, Quaternion.identity, at);
            return _playerGameObject;
        }

    }
}