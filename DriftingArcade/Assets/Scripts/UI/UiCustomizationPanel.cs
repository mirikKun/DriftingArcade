using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    public class UiCustomizationPanel : MonoBehaviour
    {
        [SerializeField] private Button _backButton;
        private RoomMediator _mediator;
        [Inject]
        private void Construct(RoomMediator mediator)
        {
            _mediator = mediator;
        }
        private void Start()
        {
            _backButton.onClick.AddListener((() =>
            {
                _mediator.OpenPreviousPanel();
                _mediator.ResetCarCustomization();
            }));

        
     
        }
    }
}
