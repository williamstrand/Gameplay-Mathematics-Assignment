using UnityEngine;

namespace Assignment_2___3
{
    public class PlayerCar : CarController
    {
        protected override void Update()
        {
            base.Update();

            var hAxis = Input.GetAxis("Horizontal");
            var vAxis = Input.GetAxis("Vertical");

            TargetTurnSpeed = hAxis * TurnSpeed;
            TargetSpeed = vAxis * Speed;
        }
    }
}