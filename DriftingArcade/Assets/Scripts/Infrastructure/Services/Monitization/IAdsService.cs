using System;

namespace Infrastructure.Services.Monitization
{
    public interface IAdsService
    {
        event Action RewardedVideoReady;
        bool IsRewardedVideoReady { get; }
        void ShowRewardedVideo(Action onVideoFinished);
    }
}