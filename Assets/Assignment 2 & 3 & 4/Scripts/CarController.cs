using UnityEngine;

namespace Assignment_2___3___4
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] protected float Speed;
        [SerializeField] protected float TurnSpeed;

        [SerializeField] protected float TurnAcceleration;
        [SerializeField] protected float Acceleration;

        protected float CurrentSpeed;
        protected float CurrentTurnSpeed;

        protected float TargetSpeed;
        protected float TargetTurnSpeed;

        [SerializeField] Vector3 colliderBounds;

        [SerializeField] CarController other;

        protected virtual void Update()
        {
            var otherPos = other.transform.position;
            var colliding = IntersectionUtilities.AABBIntersection(
                transform.position - colliderBounds / 2,
                transform.position + colliderBounds / 2,
                otherPos - other.colliderBounds / 2,
                otherPos + other.colliderBounds / 2);

            if (colliding)
            {
                if (CurrentSpeed != 0)
                {
                    var dirToOther = otherPos - transform.position;
                    var moveDir = transform.forward * CurrentSpeed;

                    if (Vector3.Dot(dirToOther, moveDir) > 0)
                    {
                        CurrentSpeed = 0;
                        TargetSpeed = 0;

                        return;
                    }
                }
            }

            CurrentSpeed = Mathf.Lerp(CurrentSpeed, TargetSpeed, Acceleration * Time.deltaTime);
            CurrentTurnSpeed = Mathf.Lerp(CurrentTurnSpeed, TargetTurnSpeed, TurnAcceleration * Time.deltaTime);
        }

        protected virtual void FixedUpdate()
        {
            transform.Translate(CurrentSpeed * Time.fixedDeltaTime * Vector3.forward);
            transform.Rotate(Vector3.up, CurrentTurnSpeed * Time.fixedDeltaTime);
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.DrawWireCube(transform.position, colliderBounds);
        }
    }
}