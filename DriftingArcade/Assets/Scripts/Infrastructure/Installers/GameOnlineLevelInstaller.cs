using UI;
using UnityEngine;
using Zenject;

public class GameOnlineLevelInstaller : MonoInstaller
{
    [SerializeField] private GameOnlineLevelMediator _mediator;

    [SerializeField] private Game _game;

    public override void InstallBindings()
    {
        BindMediator();

        BinGame();
    }



    private void BindMediator()
    {
        Container
            .Bind<GameOnlineLevelMediator>()
            .FromInstance(_mediator)
            .AsSingle();
        Container.Bind<IGameMediator>().FromInstance(_mediator);
    }
    private void BinGame()
    {
        Container
            .Bind<Game>()
            .FromInstance(_game)
            .AsSingle();
    }
}
