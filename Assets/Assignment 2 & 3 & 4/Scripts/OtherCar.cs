namespace Assignment_2___3___4
{
    public class OtherCar : CarController
    {
        protected override void Update()
        {
            base.Update();

            TargetTurnSpeed = TurnSpeed;
            TargetSpeed = Speed;
        }
    }
}