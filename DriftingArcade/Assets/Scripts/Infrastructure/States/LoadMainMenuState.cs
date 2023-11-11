using CodeBase.Infrastructure.Logic;

namespace CodeBase.Infrastructure.States
{
    public class LoadMainMenuState:IState
    {
        private const string MainMenu = "Room";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;

        public LoadMainMenuState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
        }
        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            _gameStateMachine.Enter<GameLoopState>();

        }
        public void Enter()
        {
            _curtain.Show();
            _sceneLoader.Load(MainMenu,OnLoaded);
            
        }
    }
}