using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
  public class GameBootstrapper : MonoBehaviour
  {
   private GameStateMachine _stateMachine;
   public void Setup(GameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
      _stateMachine.Enter<BootstrapState>();
      DontDestroyOnLoad(this);
    }
 
  }
}