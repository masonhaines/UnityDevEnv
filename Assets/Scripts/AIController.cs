using AIState;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private PatrolComponent patrol;
    private ChaseComponent chase;
    
    private IAiStates currentState;
    void Start()
    {
        // currentState = new PatrolState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update(this); 
    }
    
    public void TransitionTo(IAiStates newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
}
