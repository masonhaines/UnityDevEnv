using UnityEngine;

public interface ITarget
{
    bool bHasReachedTarget { get; set; }
    void newTargetLocation(Vector2 moveToTargetLocation);
}


