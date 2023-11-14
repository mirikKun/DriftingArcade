using System;
using Infrastructure.Services.Monitization;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class GameEndReward : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _rewardText;
        [SerializeField] private Button _showRewardedAdButton;

        [SerializeField] private GameObject[] _adActiveObjects;

        private IAdsService _adsService;
        private IPersistentProgressService _progress;

        private int _currentCoins;
        private ISaveLoadService _saveLoadService;

        [Inject]
        private void Construct(IPersistentProgressService progress, IAdsService adsService,
            ISaveLoadService saveLoadService)
        {
            _adsService = adsService;
            _progress = progress;

            _saveLoadService = saveLoadService;
            RefreshAvailableAd();
        }

        public void InitializeReward(int coins)
        {
            _currentCoins = coins;
            _progress.PlayerData.MoneyData.Collect(coins);

            UpdateReward(coins);
        }

        private void UpdateReward(int coins)
        {
            UpdateRewardText(coins);
            _saveLoadService.SaveProgress();
        }

        private void UpdateRewardText(int coins)
        {
            _rewardText.text = coins.ToString();
        }

        private void Start()
        {
            RefreshAvailableAd();
            _adsService.RewardedVideoReady += RefreshAvailableAd;
            _showRewardedAdButton.onClick.AddListener(OnShowAdClicked);
        }

        private void OnDestroy() => EventClear();

        private void EventClear() => _adsService.RewardedVideoReady -= RefreshAvailableAd;

        private void RefreshAvailableAd()
        {
            bool videoReady = _adsService.IsRewardedVideoReady;
            Debug.Log(_adsService.IsRewardedVideoReady);
            foreach (GameObject activeObjects in _adActiveObjects)
            {
                activeObjects.SetActive(videoReady);
            }
        }

        private void HideAdReward()
        {
            foreach (GameObject activeObjects in _adActiveObjects)
            {
                activeObjects.SetActive(false);
            }
        }

        public void OnShowAdClicked()
        {
            _adsService.ShowRewardedVideo(GetReward);
        }

        private void GetReward()
        {
            EventClear();
            HideAdReward();
            GetDoubleCoins();
        }

        private void GetDoubleCoins()
        {
            _progress.PlayerData.MoneyData.Collect(_currentCoins);
            _currentCoins *= 2;
            UpdateReward(_currentCoins);
        }
    }
}