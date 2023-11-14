using UI;
using UnityEngine;
using Zenject;

public class GameOnlineLevelInstaller : MonoInstaller
{
    [SerializeField] private GameOnlineLevelMediator _mediator;
    [SerializeField] private GameEndReward _gameEndReward;

    [SerializeField] private Game _game;

    public override void InstallBindings()
    {
        BindGameEndRewarder();
        BindMediator();
        BindGame();
    }

    private void BindGameEndRewarder()
    {
        Container
            .Bind<GameEndReward>()
            .FromInstance(_gameEndReward)
            .AsSingle();    
    }


    private void BindMediator()
    {
        Container
            .Bind<GameOnlineLevelMediator>()
            .FromInstance(_mediator)
            .AsSingle();
        Container.Bind<IGameMediator>().FromInstance(_mediator);
    }
    private void BindGame()
    {
        Container
            .Bind<Game>()
            .FromInstance(_game)
            .AsSingle();
    }
}
