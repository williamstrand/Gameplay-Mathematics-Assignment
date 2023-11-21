using UnityEngine;

namespace Assignment_5
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform followTarget;
        [SerializeField] float speed = 1;

        void Update()
        {
            transform.position = Vector3.Lerp(transform.position, followTarget.position, speed * Time.deltaTime);
        }
    }
}