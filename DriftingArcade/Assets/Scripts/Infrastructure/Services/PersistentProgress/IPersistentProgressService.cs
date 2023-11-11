using CodeBase.Infrastructure.States;
using Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public interface IPersistentProgressService : IService
  {
    PlayerData Data { get; set; }
  }
}