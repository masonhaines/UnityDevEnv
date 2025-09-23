using Unity.VisualScripting;
using UnityEngine;
using AiMovement;

public class PatrolComponent : MonoBehaviour
{

    [SerializeField] private int numberOfActivePatrolPoints;
    [SerializeField] private Transform[] patrolPointLocations;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int patrolPointCount = transform.childCount; // get all children of patrol prefab
        if (numberOfActivePatrolPoints > patrolPointCount)
        {
            numberOfActivePatrolPoints = patrolPointCount;
        }
        
        patrolPointLocations = new Transform[numberOfActivePatrolPoints];
        for (int i = 0; i < numberOfActivePatrolPoints; i++)
        {
            patrolPointLocations[i] = transform.GetChild(i); // get child of prefab and add to array 
        }
    }

    private IMove moveRef;
    
    void Awake()
    {
        moveRef = GetComponentInParent<IMove>(); // reference to all other objects that have implement interface in parent prefab
        
    }
    
    private Vector2 targetPosition;
    private int currentPatrolIndex = 0;
    
    void Update() // Update is called once per frame
    {
        if (moveRef != null && moveRef.bHasMoved)
        {
            targetPosition = new Vector2(patrolPointLocations[currentPatrolIndex].position.x, patrolPointLocations[currentPatrolIndex].position.y);

            moveRef.newTargetLocation(targetPosition);
            if (currentPatrolIndex < numberOfActivePatrolPoints - 1)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            
            moveRef.bHasMoved = false;
        }
    }
    
}
