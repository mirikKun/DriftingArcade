using System;
using UnityEngine;
using Zenject;

namespace Infrastructure.Services.Monitization
{
    public class AdsService : IAdsService
    {
        private const string AppKey = "1c74b9da5";

        public event Action RewardedVideoReady;
        private event Action _onVideoFinished;

        [Inject]
        public AdsService()
        {
            IronSource.Agent.init(AppKey);
            IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompleteEvent;

            InitialiseIronSourceCallbacks();
        }

        private void InitialiseIronSourceCallbacks()
        {
            IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
            IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
            IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;
            IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
            IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
            IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
            IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;
        }



        public bool IsRewardedVideoReady=>IronSource.Agent.isRewardedVideoAvailable();

    
        public void ShowRewardedVideo(Action onVideoFinished)
        {
            IronSource.Agent.showRewardedVideo();
            _onVideoFinished = onVideoFinished;

        }
        private void SdkInitializationCompleteEvent()
        {
            IronSource.Agent.validateIntegration();
        }


        private  void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdAvailable{adInfo}");
            RewardedVideoReady?.Invoke();

        }

        private void RewardedVideoOnAdUnavailable()
        {
            Debug.Log($"RewardedVideoOnAdUnavailable");

        }


        private  void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdOpenedEvent{adInfo.ab}");
        }


        private   void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdClosedEvent{adInfo.ab}");

        }


        private  void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdRewardedEvent{adInfo.ab}");
            _onVideoFinished?.Invoke();
            _onVideoFinished = null;
        }


        private  void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdShowFailedEvent{adInfo.ab}");

        }

        
        private void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
        {
            Debug.Log($"RewardedVideoOnAdClickedEvent{adInfo.ab}");

        }
    }
}