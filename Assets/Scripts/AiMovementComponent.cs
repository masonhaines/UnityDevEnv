using UnityEngine;
using AiMovement;
public class AiMovementComponent : MonoBehaviour, IMove
{
    [SerializeField] private float moveSpeed = 5f;
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
    }

    public void Moving(Vector2 targetLocationToMoveTo)
    {
        // throw new System.NotImplementedException();
        moversRigidbody2D.transform.position = Vector2.MoveTowards(moversRigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime);
        // _rigidbody2D.MovePosition(Vector2.MoveTowards(_rigidbody2D.transform.position, targetLocation, moveSpeed * Time.deltaTime));
    }


    public void newTargetLocation(Vector2 patrolPointTargetLocation)
    {
        this.targetLocation = patrolPointTargetLocation;
    }

    public bool canMove()
    {
        throw new System.NotImplementedException();
    }
}
