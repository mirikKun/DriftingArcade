using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.Fabric
{
    public class IGameFactory:IService
    {
        public GameObject CreateHero(GameObject at)
        {
            throw new System.NotImplementedException();
        }

        public void CreateHud()
        {
            throw new System.NotImplementedException();
        }
    }
}