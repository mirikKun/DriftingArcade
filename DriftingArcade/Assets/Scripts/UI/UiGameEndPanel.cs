using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiGameEndPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _toRoomButton;
    private GameLevelMediator _mediator;

    [Inject]
    private void Construct(GameLevelMediator mediator)
    {
        _mediator = mediator;
    }
    private void Start()
    {
        //_restartButton.onClick.AddListener(_mediator.OpenPreviousPanel);
        _toRoomButton.onClick.AddListener(_mediator.GoToRoomScene);
        
    }
}
