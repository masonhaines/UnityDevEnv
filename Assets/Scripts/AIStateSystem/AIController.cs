using System;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] private int attackRange = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PatrolState patrol;
    private ChaseState chase;
    private DeathState death;
    
    public PatrolComponent patrolComponentObject;
    public ChaseComponent chaseComponentObject;
    public AiMovementComponent movementComponentObject;
    public HealthComponent healthComponentObject;
    public Transform DetectedTargetTransform;
    public Animator myAnimator;
    
    private IAiStates currentState;
    public bool bHasPerceivedTarget;
    public bool bIsAttacking;
    public bool bInRangeToAttack;
    

    private void Awake()
    {
        patrolComponentObject = GetComponent<PatrolComponent>();
        chaseComponentObject = GetComponent<ChaseComponent>();
        movementComponentObject = GetComponent<AiMovementComponent>(); // this is for states access
        healthComponentObject = GetComponent<HealthComponent>();
        myAnimator = GetComponentInChildren<Animator>(); // this is because the animator is in the sprite child object of the enemy prefab 
        
        // add a health component listener for on death 
        healthComponentObject.OnDeathCaller += OnDeathListener;
        
        
        // // get player transform
        // GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        // if (playerObj != null)
        // {
        //     PlayerTransform = playerObj.transform; // this new ref needs to be given to the perception component
        // }
        // else
        // {
        //     Debug.LogError("Player object with tag 'Player' not found in the scene.");
        // }
    }

    public void PerceptionTargetFound(Transform target)
    {
        bHasPerceivedTarget = true;
        setNewState(chase);
        DetectedTargetTransform = target;
    }

    public void PerceptionTargetLost(Transform target)
    {
        bHasPerceivedTarget = false;
        var lastKnownTargetTransform = target;
        DetectedTargetTransform = lastKnownTargetTransform;
    }

    private void Start()
    {
        patrol = new PatrolState(this);
        chase = new ChaseState(this);
        death = new DeathState(this);
        setNewState(patrol);
    }

    // Update is called once per frame
    private void Update()
    {
        currentState.PollPerception(this);

        if (bHasPerceivedTarget)
        {
            
            // https://docs.unity3d.com/6000.2/Documentation/ScriptReference/Vector3-sqrMagnitude.html
            var differenceInVectors = DetectedTargetTransform.position - transform.position;
            var distanceFromPlayer = differenceInVectors.sqrMagnitude;
            if (distanceFromPlayer < attackRange * attackRange)
            {
                bInRangeToAttack = true;
            } 
            else { bInRangeToAttack = false; }
        }
    }
    
    public void setNewState(IAiStates newState)
    {
        if (currentState != null) // if the current state is not valid, exit the state
        {
            currentState.Exit(this);
        }
        currentState = newState; // set the current state to the new state 
        currentState.Enter(this); // call the currentstate's enter method to truly enable the state
    }

    private void OnDeathListener()
    {
        // this really should set the enemy location to somewhere else and a system is added in the scene and checks 
        // on tick for objects with enemy tag and if they are dead.
        setNewState(death);
    }
}
