using UnityEngine;
using Zenject;

namespace DefaultNamespace
{
    public class AndroidInput : IInput
    {

        public float RotateInput { get; set; }
        public float GasInput { get; set; }


        public void TurnOnGas()
        {
            GasInput = 1;
            
        }

        public void TurnOffGas()
        {
            GasInput = 0;
        }

        public void UpdateInputs(Vector2 direction)
        {
            RotateInput = direction.x;
        }
    }
}