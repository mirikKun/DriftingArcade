using Infrastructure.Fabric;
using UnityEngine;
using Zenject;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private CameraTargeter _cameraTargeter;
    private IGameFactory _gameFactory;
    private Game _game;

    [Inject]
    private void Construct(IGameFactory gameFactory, Game game)
    {
        _gameFactory = gameFactory;
        _game = game;
    }

    private void Start()
    {
        GameObject car = _gameFactory.CreateOnlinePlayer(_spawnPoint);
        _game.SetPlayer(car.GetComponent<CarMover>());
        _cameraTargeter.SetupTarget(car.transform);
    }
}