using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float jumpForce = 25f;
    [SerializeField] private int maxJumps = 2; // inlcudes 1
    [SerializeField] private float coyoteTime = 0.1f; // forgiveness window


    private PlayerControls playerControls;
    private Vector2 WASDEvent;
    private Rigidbody2D myRigidBody;
    private bool jumpPressed;
    private int jumpsRemaining;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    private float lastOnGroundTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Awake()
    {
        playerControls = new PlayerControls();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();

        lastOnGroundTime -= Time.deltaTime;
        if (GroundCollider.IsTouchingLayers(GroundLayer))
        {
            lastOnGroundTime = coyoteTime;
            jumpsRemaining = maxJumps;
        }
    }

    void FixedUpdate() // thi should be used for all thing physics 
    {
        PlayerMove();
        PlayerJump();
    }

    private void PlayerInput()
    {
        WASDEvent = playerControls.Movement.Move.ReadValue<Vector2>();
        if (playerControls.Jumping.Jump.WasPressedThisFrame())
        {
            jumpPressed = true;
            Debug.Log("I am currently trying to jump");
        }

    }

    private void PlayerMove() // recieves input from input action map inside of editor 
    {
        // myRigidBody.MovePosition(myRigidBody.position + WASDEvent * (moveSpeed * Time.fixedDeltaTime));

        // Vector2 newPosition = myRigidBody.position + WASDEvent * (moveSpeed * Time.fixedDeltaTime);
        // newPosition.y = myRigidBody.position.y + myRigidBody.linearVelocity.y * Time.fixedDeltaTime;

        // myRigidBody.MovePosition(newPosition);

        myRigidBody.linearVelocity = new Vector2(WASDEvent.x * moveSpeed, myRigidBody.linearVelocity.y);

    }

    private void PlayerJump() // recieves input from input action map inside of editor 
    {
        if (jumpPressed && (lastOnGroundTime > 0f || jumpsRemaining > 1))
        {
            // myRigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x, jumpForce);

            jumpPressed = false;      // consume input
            lastOnGroundTime = 0f;    // reset coyote timer
            jumpsRemaining--;         // use up one jump
        }
        jumpPressed = false;
    }
}
