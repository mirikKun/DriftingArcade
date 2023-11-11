﻿using CodeBase.Data;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using Data;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";
    
    private readonly IPersistentProgressService _progressService;

    [Inject]
    public SaveLoadService(IPersistentProgressService progressService)
    {
      _progressService = progressService;
    }

    public void SaveProgress()
    {
      PlayerPrefs.SetString(ProgressKey, _progressService.PlayerData.ToJson());
    }

    public PlayerData LoadProgress()
    {
      return PlayerPrefs.GetString(ProgressKey)?
        .ToDeserialized<PlayerData>();
    }
  }
}