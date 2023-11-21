using UnityEngine;

namespace Assignment_2___3___4
{
    public static class IntersectionUtilities
    {
        public static bool AABBIntersection(Vector3 aMin, Vector3 aMax, Vector3 bMin, Vector3 bMax)
        {
            var x = aMin.x <= bMax.x && aMax.x >= bMin.x;
            var y = aMin.y <= bMax.y && aMax.y >= bMin.y;
            var z = aMin.z <= bMax.z && aMax.z >= bMin.z;

            return x && y && z;
        }
    }
}