using UnityEngine;

namespace DefaultNamespace
{
    public interface IInput
    {
        public float RotateInput { get; set; }
        public float GasInput { get; set; }
        void TurnOnGas();
        void TurnOffGas();
        void UpdateInputs(Vector2 direction);
    }
}