using UnityEngine;

namespace Assignment_1
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] MeshRenderer meshRenderer;
        [SerializeField] Transform player;

        bool playerFound;
        [SerializeField] float speed;
        [SerializeField] float visionCone = 0.75f;
        [SerializeField] float visionRange;

        void Update()
        {
            if (playerFound) return;

            playerFound = TargetInVision(player);
        }

        void FixedUpdate()
        {
            if (playerFound)
            {
                ChasePlayer();
            }
            else
            {
                LookForPlayer();
            }
        }

        void ChasePlayer()
        {
            var dirToPlayer = (player.position - transform.position).normalized;
            transform.position += speed * Time.fixedDeltaTime * dirToPlayer;
            transform.LookAt(player, Vector3.up);
        }

        void LookForPlayer()
        {
            transform.Rotate(Vector3.up, 90 * Time.fixedDeltaTime);
        }

        bool TargetInVision(Transform target)
        {
            var ctx = ContextUtilities.GetContext(transform, target, visionRange, visionCone);
            var inRange = (ctx & Context.InRange) == Context.InRange;
            var inVisionCone = (ctx & Context.CanSee) == Context.CanSee;

            return inRange && inVisionCone;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, visionRange);
        }
    }
}