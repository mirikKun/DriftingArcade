﻿using Infrastructure.Logic;

namespace Infrastructure.States
{
  public class LoadLevelState : IState
  {
    private const string MainLevel = "Main";
    private readonly GameStateMachine _stateMachine;
    private readonly SceneLoader _sceneLoader;
    private readonly LoadingCurtain _curtain;

    public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
      _curtain = curtain;
    }
    public void Enter()
    {
      _curtain.Show();
      _sceneLoader.Load(MainLevel,OnLoaded);
    }
    public void Exit()
    {
      _curtain.Hide();
    }
    private void OnLoaded()
    {
      _stateMachine.Enter<GameLoopState>();
    }
  }
}