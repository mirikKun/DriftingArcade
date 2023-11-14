using UnityEngine;

namespace Infrastructure.Services.Monitization
{
    public class AdsLifecycle:MonoBehaviour
    {
        
        private void OnApplicationPause(bool isPaused)
        {
            IronSource.Agent.onApplicationPause(isPaused);
        }

    }
}