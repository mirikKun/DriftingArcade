using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

public class RoomMediator : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _roomPanel;
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private GameObject _customizationPanel;
    private readonly PanelsSwitch _panelsSwitch=new ();
    private GameStateMachine _gameStateMachine;

    [Inject]
    private void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    private void Start()
    {
        _panelsSwitch.Init(_mainMenu);
    }

    public void OpenSingleLevel() => _gameStateMachine.Enter<LoadLevelState>();

    public void OpenPreviousPanel() => _panelsSwitch.Back();
    public void OpenMainMenu() => _panelsSwitch.OpenPanel(_mainMenu);
    public void OpenRoomPanel() => _panelsSwitch.OpenPanel(_roomPanel);
    public void OpenShopPanel() => _panelsSwitch.OpenPanel(_shopPanel);
    public void OpenCustomizationPanel() => _panelsSwitch.OpenPanel(_customizationPanel);
}
