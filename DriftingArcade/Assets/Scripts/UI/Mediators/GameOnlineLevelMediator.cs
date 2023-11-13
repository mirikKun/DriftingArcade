using Infrastructure;
using Infrastructure.States;
using UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOnlineLevelMediator:MonoBehaviour,IGameMediator
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private GameObject _gameEndPanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Game _game;

    private PanelsSwitch _panelsSwitch;
    private PhotonDisconnector _photonDisconnector;

    [Inject]
    private void Construct(PhotonDisconnector photonDisconnector)
    {
        _photonDisconnector = photonDisconnector;
    }
    private void Start()
    {
        _panelsSwitch = new PanelsSwitch(_pauseButton.gameObject);
        _pauseButton.onClick.AddListener(OpenPauseMenu);
    }

    public void OpenPauseMenu() => _panelsSwitch.OpenPanel(_pausePanel);
    public void OpenGameEndPanel() => _panelsSwitch.OpenPanel(_gameEndPanel);
    public void OpenPreviousPanel() => _panelsSwitch.Back();
    public void ToLobby() => _photonDisconnector.LoadBackToLobby();
}