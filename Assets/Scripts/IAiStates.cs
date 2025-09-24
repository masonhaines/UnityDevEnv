using UnityEngine;

namespace AIState
{
    public interface IAiStates
    {
        void Enter(AIController aiController);
        void Update(AIController aiController); // this needs to be named something else, like pollstates, or updatestates, pollandchangestate
        void Exit(AIController aiController);
    }
}

