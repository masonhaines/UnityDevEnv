using UnityEngine;

namespace AiMovement
{
    public interface IMove
    {
        bool bHasMoved { get; set; }
        void newTargetLocation(Vector2 patrolPointTargetLocation);
    }
}

