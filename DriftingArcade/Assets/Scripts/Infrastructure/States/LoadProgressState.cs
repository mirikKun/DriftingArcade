using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using Data;

namespace CodeBase.Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;

    public LoadProgressState(GameStateMachine gameStateMachine, IPersistentProgressService progressService,
      ISaveLoadService saveLoadService)
    {
      _gameStateMachine = gameStateMachine;
      _progressService = progressService;
      _saveLoadService = saveLoadService;
    }

    public void Enter()
    {
      LoadProgressOrInitNew();
      _gameStateMachine.Enter<LoadMainMenuState>();
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew() =>
      _progressService.Data =
        _saveLoadService.LoadProgress()
        ?? NewProgress();

    private PlayerData NewProgress() => new();
  }
}