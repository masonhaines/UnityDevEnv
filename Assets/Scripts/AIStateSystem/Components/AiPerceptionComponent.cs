using UnityEngine;

public class AiPerceptionComponent : MonoBehaviour
{
    [SerializeField] private int distanceFromTarget;
    private AIController aiController;

    private void Awake()
    {
        aiController = GetComponent<AIController>();
    }
    
    private void OnTriggerEnter2D(Collider2D newTarget)
    {
        if (newTarget.CompareTag("Player"))
        {
            aiController.PerceptionTargetFound(newTarget.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D newTarget)
    {
        if (newTarget.CompareTag("Player"))
        {
            aiController.PerceptionTargetLost(newTarget.transform);
        }
    }
}
