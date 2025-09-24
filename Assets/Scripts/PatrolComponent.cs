using Unity.VisualScripting;
using UnityEngine;
using AiMovement;

public class PatrolComponent : MonoBehaviour
{

    [SerializeField] private Transform[] patrolPointLocations;
    [SerializeField] private float waitTimeBetweenPatrolPoints;
    private int numberOfActivePatrolPoints;
    private float decrementTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        numberOfActivePatrolPoints = patrolPointLocations.Length;
    }

    private ITarget moveRef;
    
    void Awake()
    {
        moveRef = GetComponentInParent<ITarget>(); // reference to all other objects that have implement interface in parent prefab
    }
    
    private Vector2 targetPosition;
    private int currentPatrolIndex = 0;
    
    void Update() // Update is called once per frame
    {
        if (moveRef == null) return;


        if (moveRef.bHasReachedTarget)
        {
            if (decrementTimer <= 0f)
            {
                if (currentPatrolIndex < numberOfActivePatrolPoints - 1)
                {
                    // Debug.Log($"Current Patrol Index: {currentPatrolIndex}");
                    currentPatrolIndex++;
                }
                else
                {
                    currentPatrolIndex = 0;
                }
            
                // targetPosition = new Vector2(patrolPointLocations[currentPatrolIndex].position.x, patrolPointLocations[currentPatrolIndex].position.y);
                targetPosition = patrolPointLocations[currentPatrolIndex].position; 
                moveRef.newTargetLocation(targetPosition);
                decrementTimer = waitTimeBetweenPatrolPoints; // reset
            }
            else
            {
                decrementTimer -= Time.deltaTime;
            }
        }
    }
}
