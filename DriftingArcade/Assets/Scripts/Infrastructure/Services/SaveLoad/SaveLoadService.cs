using CodeBase.Data;
using CodeBase.Infrastructure.Fabric;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.States;
using Data;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";
    
    private readonly IGameFactory _gameFactory;
    private readonly IPersistentProgressService _progressService;

    public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
    {
      _progressService = progressService;
      _gameFactory = gameFactory;
    }

    public void SaveProgress()
    {
      // foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
      //   progressWriter.UpdateProgress(_progressService.Progress);
      //
      // PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }

    public PlayerData LoadProgress()
    {
      return PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerData>();
    }
  }
}