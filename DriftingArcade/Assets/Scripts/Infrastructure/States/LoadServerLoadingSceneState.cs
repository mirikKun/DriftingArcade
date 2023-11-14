

namespace Infrastructure.States
{
    public class LoadServerLoadingSceneState : IState
    {
        private const string SceneName = "OnlineConnecting";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        public LoadServerLoadingSceneState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
                 }

        public void Enter()
        {
            _sceneLoader.Load(SceneName,OnLoaded);

        }
        public void Exit()
        {
        }
        private void OnLoaded()
        {
            //PhotonNetwork.ConnectUsingSettings();
        }
    }
}