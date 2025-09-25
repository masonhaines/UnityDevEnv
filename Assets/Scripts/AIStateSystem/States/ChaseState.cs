using UnityEngine;
using Unity.VisualScripting;

public class ChaseState : IAiStates
{
    private AIController aiControllerInstance;
    private bool hasPercievedTarget; // this needs to be changed to get the ref from ai controller because it should be instantiated its own instance of the perception component

    public ChaseState(AIController aiControllerInstance)
    {
        this.aiControllerInstance = aiControllerInstance;
    }
    public void Enter(AIController aiController)
    {
        aiControllerInstance.chaseComponentObject.enabled = true;
    }

    public void PollPerception(AIController aiController)
    {
        if (!hasPercievedTarget)
        {
            aiControllerInstance.setNewState(new PatrolState(this.aiControllerInstance));
        }
    }

    public void Exit(AIController aiController)
    {
        aiControllerInstance.chaseComponentObject.enabled = false;
    }
}
        
