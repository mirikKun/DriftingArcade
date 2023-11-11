using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Fabric;
using CodeBase.Infrastructure.Logic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using Zenject;

namespace CodeBase.Infrastructure.States
{
  public class GameStateMachine
  {
    private readonly Dictionary<Type, IExitableState> _states;
    private IExitableState _activeState;

    [Inject]
    public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain,IGameFactory gameFactory,IPersistentProgressService progressService,ISaveLoadService saveLoadService)
    {
      _states = new Dictionary<Type, IExitableState>()
      {
        [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader),
        [typeof(LoadProgressState)] = new LoadProgressState(this, progressService, saveLoadService),
        [typeof(LoadMainMenuState)] = new LoadMainMenuState(this,sceneLoader,curtain),
        [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, gameFactory, progressService),
        [typeof(GameLoopState)] = new GameLoopState(this),
        [typeof(RoomLoopState)] = new RoomLoopState(this),
      };
    }

    public void Enter<TState>() where TState : class, IState
    {
      IState state = ChangeState<TState>();
      state.Enter();
    }

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
    {
      TState state = ChangeState<TState>();
      state.Enter(payload);
    }

    private TState ChangeState<TState>() where TState : class, IExitableState
    {
      _activeState?.Exit();

      TState state = GetState<TState>();
      _activeState = state;

      return state;
    }

    private TState GetState<TState>() where TState : class, IExitableState =>
      _states[typeof(TState)] as TState;
  }
}