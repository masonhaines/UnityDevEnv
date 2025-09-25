using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.UIElements.Experimental;
public class AiMovementComponent : MonoBehaviour, ITarget
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool bLocalHasMovedToTarget = true;
    public bool bHasReachedTarget { get => bLocalHasMovedToTarget; set => bLocalHasMovedToTarget = value; }
    private Rigidbody2D moversRigidbody2D;
    private Vector2 targetLocation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moversRigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(targetLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if (!bLocalHasMovedToTarget)
        {
            Moving(targetLocation);
        }
        
        // Debug.Log(moversRigidbody2D.linearVelocity.magnitude);Debug.Log($"HasMoved: {bLocalHasMovedToTarget}, Target: {targetLocation}");
        // Debug.Log($"HasMoved: {bLocalHasMovedToTarget}, Target: {targetLocation}");

        
    }

    public void Moving(Vector2 targetLocationToMoveTo)
    {
        // throw new System.NotImplementedException();
        // moversRigidbody2D.transform.position = Vector2.MoveTowards(moversRigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime);
        moversRigidbody2D.MovePosition(Vector2.MoveTowards(moversRigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime));

        // if (abs(moversRigidbody2D.transform.position.y - targetLocation.y) >= 0.1f) return;
        if (Mathf.Abs(moversRigidbody2D.position.x - targetLocation.x) <= 0.1f && !bLocalHasMovedToTarget)
        {
            // Reached the target location
            bLocalHasMovedToTarget = true;
            moversRigidbody2D.position = targetLocation;
        }
    }


    public void newTargetLocation(Vector2 moveToTargetLocation)
    {
        targetLocation = moveToTargetLocation;
        bLocalHasMovedToTarget = false;
        Debug.Log(targetLocation);

    }


}
