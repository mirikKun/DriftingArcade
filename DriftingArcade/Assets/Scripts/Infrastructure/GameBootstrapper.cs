using System.Security;
using CodeBase.Infrastructure.Logic;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
  public class GameBootstrapper : MonoBehaviour
  {
    [Inject] private GameStateMachine _stateMachine;
    
    public void Construct(GameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    private void Start()
    {
      _stateMachine.Enter<BootstrapState>();
      DontDestroyOnLoad(this);
    }
  }
}