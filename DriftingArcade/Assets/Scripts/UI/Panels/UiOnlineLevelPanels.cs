using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UiOnlineLevelPanels : MonoBehaviour
{
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _toLobbyButton;
    [SerializeField] private Button _toLobbyButton2;
    private GameOnlineLevelMediator _mediator;

    [Inject]
    private void Construct(GameOnlineLevelMediator mediator)
    {
        _mediator = mediator;
    }
    private void Start()
    {
        _continueButton.onClick.AddListener(_mediator.OpenPreviousPanel);
        _toLobbyButton.onClick.AddListener(_mediator.ToLobby);
        _toLobbyButton2.onClick.AddListener(_mediator.ToLobby);
        
    }
}
