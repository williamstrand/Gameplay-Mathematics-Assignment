using UnityEngine;

namespace Assignment_2
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] protected float speed;
        [SerializeField] protected float turnSpeed;

        [SerializeField] protected float turnAcceleration;
        [SerializeField] protected float acceleration;

        protected float currentSpeed;
        protected float currentTurnSpeed;

        protected float targetSpeed;
        protected float targetTurnSpeed;

        protected virtual void Update()
        {
            currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
            currentTurnSpeed = Mathf.Lerp(currentTurnSpeed, targetTurnSpeed, turnAcceleration * Time.deltaTime);
        }

        protected virtual void FixedUpdate()
        {
            transform.Translate(currentSpeed * Time.fixedDeltaTime * Vector3.forward);
            transform.Rotate(Vector3.up, currentTurnSpeed * Time.fixedDeltaTime);
        }
    }
}