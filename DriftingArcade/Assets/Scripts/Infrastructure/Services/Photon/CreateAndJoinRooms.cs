using Infrastructure.States;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button _createButton;
    [SerializeField] private Button _joinButton;

    [SerializeField] private TMP_InputField _createInputField;
    [SerializeField] private TMP_InputField _joinInputField;
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    private void Start()
    {
        _createButton.onClick.AddListener(CreateRoom);
        _joinButton.onClick.AddListener(JoinRoom);
    }

    private void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_createInputField.text);
    }
    private void JoinRoom()
    {
        PhotonNetwork.JoinRoom(_joinInputField.text);
    }

    public override void OnJoinedRoom()
    {
        _gameStateMachine.Enter<LoadOnlineLevelState>();
    }
}
