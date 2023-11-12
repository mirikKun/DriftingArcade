using Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.States
{
  public class LoadProgressState : IState
  {
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _progressService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly Color _startCarColor = new Color(64/255f, 104/255f, 183/255f);
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
      _gameStateMachine.Enter<LoadRoomSceneState>();
    }

    public void Exit()
    {
    }

    private void LoadProgressOrInitNew() =>
      _progressService.PlayerData =
        _saveLoadService.LoadProgress()
        ?? NewProgress();

    private PlayerData NewProgress()
    {
      PlayerData newProgress = new PlayerData();
      newProgress.CustomCarData.CarColor = _startCarColor;
      newProgress.CustomCarData.AccessoriesType = AccessoriesType.None;
      return newProgress;
    }
  }
}