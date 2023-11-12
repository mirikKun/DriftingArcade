using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace UI
{
    public class RoomMediator : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _roomPanel;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _customizationPanel;
        private PanelsSwitch _panelsSwitch;
        private GameStateMachine _gameStateMachine;
        private RoomMediator _roomMediator;
        private CarCustomizationView _carCustomizationView;

        [Inject]
        private void Construct(GameStateMachine gameStateMachine, CarCustomizationView carCustomizationView)
        {
            _gameStateMachine = gameStateMachine;
            _carCustomizationView = carCustomizationView;
        }
        private void Start()
        {
            _panelsSwitch=new PanelsSwitch (_mainMenu);
        }

        public void ResetCarCustomization() => _carCustomizationView.Reset();
        public void OpenSingleLevel() => _gameStateMachine.Enter<LoadLevelState>();

        public void OpenPreviousPanel() => _panelsSwitch.Back();
        public void OpenMainMenu() => _panelsSwitch.OpenPanel(_mainMenu);
        public void OpenRoomPanel() => _panelsSwitch.OpenPanel(_roomPanel);
        public void OpenShopPanel() => _panelsSwitch.OpenPanel(_shopPanel);
        public void OpenCustomizationPanel() => _panelsSwitch.OpenPanel(_customizationPanel);
    }
}
