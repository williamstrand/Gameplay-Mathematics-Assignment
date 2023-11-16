using UnityEngine;

namespace Assignment_2
{
    public class PlayerCar : CarController
    {
        protected override void Update()
        {
            base.Update();

            var hAxis = Input.GetAxis("Horizontal");
            var vAxis = Input.GetAxis("Vertical");

            targetTurnSpeed = hAxis * turnSpeed;
            targetSpeed = vAxis * speed;
        }
    }
}