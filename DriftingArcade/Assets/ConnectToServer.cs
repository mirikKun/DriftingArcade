using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.States;
using Photon.Pun;
using UnityEngine;
using Zenject;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
   private GameStateMachine _stateMachine;
   [Inject]
   private void Construct(GameStateMachine stateMachine)
   {
      Debug.Log(1111);
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
