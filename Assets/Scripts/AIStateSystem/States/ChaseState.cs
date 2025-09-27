using UnityEngine;
using Unity.VisualScripting;

public class ChaseState : IAiStates
{
    private AIController aiControllerInstance;

    public ChaseState(AIController aiControllerInstance)
    {
        this.aiControllerInstance = aiControllerInstance;
    }
    public void Enter(AIController aiController)
    {
        aiControllerInstance.chaseComponentObject.enabled = true;
        aiController.movementComponentObject.OnTargetReachedCaller +=
            aiController.patrolComponentObject.OnTargetReachedListener;
        Debug.Log("Chase");

    }

    public void PollPerception(AIController aiController)
    {
        if (!aiControllerInstance.bHasPerceivedTarget) // has NOT
        {
            aiControllerInstance.setNewState(new PatrolState(this.aiControllerInstance));
        }
        else if (aiControllerInstance.bInRangeToAttack)
        {
            // aiControllerInstance.setNewState(new AttackState(this.aiControllerInstance));
        }
    }

    public void Exit(AIController aiController)
    {
        aiControllerInstance.chaseComponentObject.enabled = false;
        aiController.movementComponentObject.OnTargetReachedCaller -=
            aiController.patrolComponentObject.OnTargetReachedListener;
    }
}
        
