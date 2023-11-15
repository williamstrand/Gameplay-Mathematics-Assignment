using UnityEngine;

namespace Assignment_1
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] float attackRange;
        [SerializeField] float speed = 10.0f;
        [SerializeField] Transform target;

        void Update()
        {
            if (!target) return;

            if (Input.GetMouseButtonDown(0))
            {
                var ctx = ContextUtilities.GetContext(transform, target, attackRange, 1);
                if ((ctx & Context.InRange) == Context.InRange && (ctx & Context.Behind) == Context.Behind)
                {
                    Destroy(target.gameObject);
                }
            }
        }

        void FixedUpdate()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var forwardInput = Input.GetAxis("Vertical");

            var moveDir = new Vector3(horizontalInput, 0, forwardInput).normalized;
            transform.position += speed * Time.fixedDeltaTime * moveDir;
        }
    }
}