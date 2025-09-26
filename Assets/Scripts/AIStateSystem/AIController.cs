using System;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PatrolState patrol;
    private ChaseState chase;
    
    public PatrolComponent patrolComponentObject;
    public ChaseComponent chaseComponentObject;
    public AiMovementComponent movementComponentObject;
    
    
    private IAiStates currentState;

    private void Awake()
    {
        patrolComponentObject = GetComponent<PatrolComponent>();
        chaseComponentObject = GetComponent<ChaseComponent>();
        movementComponentObject = GetComponent<AiMovementComponent>();
    }

    void Start()
    {
        patrol = new PatrolState(this);
        chase = new ChaseState(this);
        setNewState(patrol);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.PollPerception(this); 
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
}
