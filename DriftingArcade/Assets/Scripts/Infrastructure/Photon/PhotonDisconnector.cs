using System.Collections;
using Infrastructure.States;
using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class PhotonDisconnector
    {
        private readonly ICoroutineRunner _coroutineRunner;
        private readonly GameStateMachine _gameStateMachine;

        [Inject]
        public PhotonDisconnector(ICoroutineRunner coroutineRunner,GameStateMachine gameStateMachine)
        {
            _coroutineRunner = coroutineRunner;
            _gameStateMachine = gameStateMachine;
        }

        public void DisconnectPlayer()
        {
            _coroutineRunner.StartCoroutine(DisconnectAndLoad());
        }

        private IEnumerator DisconnectAndLoad()
        {
            PhotonNetwork.Disconnect();
            while (PhotonNetwork.IsConnected)
                yield return null;
            Debug.Log("Disconnected");

            _gameStateMachine.Enter<LoadRoomSceneState>();
        }

        public void LoadBackToLobby()
        {
            if (PhotonNetwork.InRoom)
            {
                if (PhotonNetwork.IsMasterClient && PhotonNetwork.CurrentRoom.PlayerCount > 1) MigrateMaster();
                else
                {
                    PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.LocalPlayer);
                    _coroutineRunner.StartCoroutine(DisconnectAndLoadLobby());
                }
            }

        }
        private IEnumerator DisconnectAndLoadLobby()
        {
            PhotonNetwork.LeaveRoom();
            while (PhotonNetwork.InRoom)
                yield return null;
            Debug.Log("Returned to lobby");
            _gameStateMachine.Enter<LoadLobbyScene>();
        }
        
        private void MigrateMaster()
        {
            var dict = PhotonNetwork.CurrentRoom.Players;
            if (PhotonNetwork.SetMasterClient(dict[dict.Count - 1]))
                _coroutineRunner.StartCoroutine(DisconnectAndLoadLobby());
        }
    }
}