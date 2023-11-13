using Infrastructure.Logic;

namespace Infrastructure.States
{
    public class LoadLobbyScene : IState
    {

        private const string Lobby = "Lobby";

        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadLobbyScene(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;   
        }

        public void Enter()
        {            _curtain.Show();

            _sceneLoader.Load(Lobby,OnLoaded);
        }
        public void Exit()
        {            _curtain.Hide();

        }
        private void OnLoaded()
        {
            //PhotonNetwork.ConnectUsingSettings();
        }
    }
}