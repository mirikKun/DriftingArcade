using CodeBase.Infrastructure.Fabric;
using CodeBase.Infrastructure.Logic;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string InitialPointTag = "InitialPoint";

    private const string MainLevel = "Main";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, IGameFactory gameFactory, IPersistentProgressService progressService)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
      _gameFactory = gameFactory;
      _progressService = progressService;
    }

    public void Enter()
    {
      _curtain.Show();
      _sceneLoader.Load(MainLevel,OnLoaded);
    }

    public void Exit()
    {
      _curtain.Hide();
    }

    private void OnLoaded()
    {
      InitGameWorld();
      _stateMachine.Enter<GameLoopState>();
    }


    private void InitGameWorld()
    {
      GameObject hero = _gameFactory.CreatePlayer(at: GameObject.FindWithTag(InitialPointTag));
      
     // CameraFollow(hero);
    }

    // private static void CameraFollow(GameObject hero) =>
    //   Camera.main.GetComponent<CameraFollow>().Follow(hero);
  }
}