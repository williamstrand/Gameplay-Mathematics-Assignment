namespace Assignment_2
{
    public class OtherCar : CarController
    {
        protected override void Update()
        {
            base.Update();

            targetTurnSpeed = turnSpeed;
            targetSpeed = speed;
        }
    }
}