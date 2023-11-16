using UnityEngine;

namespace Assignment_2___3
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform player, other;

        void Update()
        {
            var playerPos = player.position;
            var otherPos = other.position;
            var midPoint = Vector3.Lerp(playerPos, otherPos, 0.5f);
            transform.position = Vector3.Lerp(transform.position, midPoint + new Vector3(0, 20, 0), Time.deltaTime);
            transform.LookAt(transform.position);
        }
    }
}