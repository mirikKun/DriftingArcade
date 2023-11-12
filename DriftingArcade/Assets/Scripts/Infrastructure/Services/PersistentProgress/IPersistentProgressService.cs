using Data;

namespace Infrastructure.Services.PersistentProgress
{
  public interface IPersistentProgressService : IService
  {
    PlayerData PlayerData { get; set; }
  }
}