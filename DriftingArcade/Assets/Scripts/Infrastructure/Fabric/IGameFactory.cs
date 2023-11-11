using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Fabric
{
    public interface IGameFactory:IService
    {
        public GameObject CreatePlayer(GameObject at);

    }
}