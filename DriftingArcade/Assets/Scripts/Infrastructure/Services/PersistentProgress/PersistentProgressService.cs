using CodeBase.Infrastructure.States;
using Data;

namespace CodeBase.Infrastructure.Services.PersistentProgress
{
  public class PersistentProgressService : IPersistentProgressService
  {
    public PlayerData Data { get; set; }
  }
}