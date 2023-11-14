using Infrastructure.States;
using Photon.Pun;
using Zenject;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
   private GameStateMachine _stateMachine;
   [Inject]
   private void Construct(GameStateMachine stateMachine)
   {
      _stateMachine = stateMachine;
   }
   private void Start()
   {
      PhotonNetwork.ConnectUsingSettings();
   }

   public override void OnConnectedToMaster()
   {
      PhotonNetwork.JoinLobby();
   }

   public override void OnJoinedLobby()
   {
      _stateMachine.Enter<LoadLobbyScene>();
   }
}
