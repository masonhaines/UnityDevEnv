using UnityEngine;

namespace AiMovement
{
    public interface IMove
    {
        void newTargetLocation(Vector2 patrolPointTargetLocation);
        bool canMove();
    }
}

