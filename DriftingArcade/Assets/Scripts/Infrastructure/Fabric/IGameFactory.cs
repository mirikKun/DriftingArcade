using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Fabric
{
    public interface IGameFactory:IService
    {
        public GameObject CreatePlayer(Transform at);

        GameObject CreateOnlinePlayer(Transform at);
    }
}