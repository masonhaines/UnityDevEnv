using UnityEngine;

namespace AiMovement
{
    public interface ITarget
    {
        bool bHasReachedTarget { get; set; }
        void newTargetLocation(Vector2 patrolPointTargetLocation);
    }
}

