using System;
using UnityEngine;

namespace Assignment_1
{
    public static class ContextUtilities
    {
        public static Context GetContext(Transform target, Transform other, float visionRange, float visionCone)
        {
            var ctx = Context.None;

            var directionToOther = other.position - target.position;
            var rangeToOtherSqr = directionToOther.sqrMagnitude;
            if (rangeToOtherSqr <= visionRange * visionRange) ctx |= Context.InRange;

            var dot = Vector3.Dot(other.forward, directionToOther);
            if (dot > 0)
            {
                ctx |= Context.Behind;
            }
            else
            {
                ctx |= Context.InFront;
            }

            dot = Vector3.Dot(target.forward, directionToOther);
            if (dot > 0)
            {
                ctx |= Context.Facing;
                if (dot > visionCone)
                {
                    ctx |= Context.CanSee;
                }
            }

            return ctx;
        }
    }

    [Flags]
    public enum Context
    {
        None,
        InRange,
        InFront,
        Behind = 4,
        CanSee = 8,
        Facing = 16
    }
}