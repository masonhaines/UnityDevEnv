using UnityEngine;

public class ChaseComponent : MonoBehaviour
{
    private Transform[] waypoints;
    private int numberOfWaypointPositions;
    private int waypointIndex = 0;
    private Vector2 targetPosition;


    private ITarget moveRef;

    private void Awake()
    {
        moveRef = GetComponentInParent<ITarget>(); // reference to all other objects that have implement interface in parent prefab
    }
    private void Start()
    {
        numberOfWaypointPositions = waypoints.Length;
        targetPosition = waypoints[waypointIndex].position;
        moveRef.NewTargetLocation(targetPosition);
    }

    public void OnTargetReachedListener()
    {
        if(moveRef == null) return;
        
    }
    
    // call me in the update of ai controller
    public void GetNewWaypoint()
    {
        
    }
    
    

}
