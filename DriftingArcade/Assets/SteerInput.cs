using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace DefaultNamespace
{
    public class SteerInput:MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerMoveHandler
    {
        [SerializeField] private RectTransform _wheelUITransform;
        [SerializeField] private Image _wheelUIImage;
   
        private bool _pressing;

        private IInput _input;
        [Inject]
        private void Construct(IInput input)
        {
            _input = input;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            _wheelUIImage.enabled = true;
            _input.TurnOnGas();
            _pressing = true;
        }


        public void OnPointerMove(PointerEventData eventData)
        {
            if (!_pressing)
                return;

            Vector2 touchPosition = eventData.position;
            Vector2 centerPosition = _wheelUITransform.position;
            Vector2 direction=touchPosition - centerPosition;
            float angle = Vector2.SignedAngle(Vector2.down, direction);
            _wheelUITransform.eulerAngles = new Vector3(0, 0, angle);
            _input.UpdateInputs(direction.normalized);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _wheelUIImage.enabled = false;
            _input.TurnOffGas();
            _pressing = false;
        }
    }
}