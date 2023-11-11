using CodeBase.Infrastructure.States;
using Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerData data);
  }

  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerData data);
  }
}