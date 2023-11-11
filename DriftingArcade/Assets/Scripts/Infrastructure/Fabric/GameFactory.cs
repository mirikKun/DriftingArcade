using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Fabric
{
    public class GameFactory:IGameFactory
    {
        private readonly IAssetProvider _assets;
        private readonly IPersistentProgressService _persistentProgressService;
        private GameObject _playerGameObject;
        private readonly string _playerPath= "PlayerCar";

        [Inject]
        public GameFactory(IAssetProvider assets, IPersistentProgressService persistentProgressService)
        {
            _assets = assets;
            _persistentProgressService = persistentProgressService;
        }
        public GameObject CreatePlayer(GameObject at)
        {
            _playerGameObject=_assets.Instantiate(path: _playerPath, at: at.transform.position);
            return _playerGameObject;
        }

    }
}