using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiCustomizationPanel : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _doneButton;
    private RoomMediator _mediator;
    [Inject]
    private void Construct(RoomMediator mediator)
    {
        _mediator = mediator;
    }
    private void Start()
    {
        _backButton.onClick.AddListener(_mediator.OpenPreviousPanel);

        
     
    }
}
