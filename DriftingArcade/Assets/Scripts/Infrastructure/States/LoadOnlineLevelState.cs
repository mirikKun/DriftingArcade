namespace Infrastructure.States
{
    public class LoadOnlineLevelState : IState
    {
        private const string MainLevel = "MainOnline";
        private readonly GameStateMachine _stateMachine;
        private readonly PhotonSceneLoader _photonSceneLoader;

        public LoadOnlineLevelState(GameStateMachine stateMachine, PhotonSceneLoader photonSceneLoader)
        {
            _stateMachine = stateMachine;
            _photonSceneLoader = photonSceneLoader;
        }

        public void Enter()
        {
            _photonSceneLoader.LoadScene(MainLevel);
        }

        public void Exit()
        {
        }
    
    }
}