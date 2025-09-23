using UnityEngine;
using AiMovement;
using UnityEngine.UIElements.Experimental;
public class AiMovementComponent : MonoBehaviour, IMove
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private bool bLocalHasMoved = true;
    public bool bHasMoved { get => bLocalHasMoved; set => bLocalHasMoved = value; }
    private Rigidbody2D moversRigidbody2D;
    private Vector2 targetLocation;

    private IMove moveImplementation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moversRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Moving(targetLocation);

        if (Vector2.Distance(moversRigidbody2D.transform.position, targetLocation) < 0.1f)
        {
            // Reached the target location
            bHasMoved = true;
        }
    }

    public void Moving(Vector2 targetLocationToMoveTo)
    {
        // throw new System.NotImplementedException();
        moversRigidbody2D.transform.position = Vector2.MoveTowards(moversRigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime);
        // _rigidbody2D.MovePosition(Vector2.MoveTowards(_rigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime));
    }


    public void newTargetLocation(Vector2 patrolPointTargetLocation)
    {
        targetLocation = patrolPointTargetLocation;
    }


}
