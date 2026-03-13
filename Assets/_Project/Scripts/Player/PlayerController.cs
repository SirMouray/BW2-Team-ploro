using UnityEngine;

//use gravity off - interpolate - collision su continuous

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GroundCheck groundCheck;
    //[SerializeField] private AnimationManager animator;

    [Header("Movement Attributes")]
    [SerializeField] private float speed = 2f;
    [SerializeField] private float speedMultiplier = 2f;
    private float currentSpeed;
    private Vector3 move;

    [Header("Rotation Attributes")]
    [SerializeField] private float rotationSmoothness = 10f;
    private Quaternion rotTarget;

    [Header("Jump Attributes")]
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float fallMultiplier = 2.5f;
    private float verticalVelocity = 0f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        if (groundCheck == null)
            groundCheck = GetComponent<GroundCheck>();

        //if (animator == null)
        //    animator = GetComponent<AnimationManager>();
    }

    private void Update()
    {
        PlayerInput();
        JumpCheck();
        SprintCheck();
    }

    private void FixedUpdate()
    {
        ApplyGravity();
        PlayerMovement();
        PlayerRotation();

        //animator.SetJumpState(groundCheck.CheckIsGrounded());
        //animator.JumpAnimation();
    }

    private void PlayerInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        move = new Vector3(horizontal, 0, vertical).normalized;
    }

    private void PlayerMovement()
    {
        Vector3 velocity = move * currentSpeed;
        velocity.y = verticalVelocity;
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    private void PlayerRotation()
    {
        if (move != Vector3.zero)
        {
            rotTarget = Quaternion.LookRotation(move);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotTarget, rotationSmoothness * Time.fixedDeltaTime));
        }
    }

    private void SprintCheck()
    {
        currentSpeed = speed;
        if (Input.GetButton("Fire3"))
            currentSpeed *= speedMultiplier;
    }

    private void ApplyGravity()
    {
        if (groundCheck.CheckIsGrounded() && verticalVelocity < 0f) 
            verticalVelocity = -2f; //se e' a terra mantienilo tale con valore minimo X (non si usa -9.81f perche' potrebbe causare compenetrazioni con il terreno)
        else                        //altrimenti applica la gravita' con fall multiplier se sta cadendo
        {
            float appliedGravity = (verticalVelocity < 0f) ? gravity * fallMultiplier : gravity;
            verticalVelocity += appliedGravity * Time.fixedDeltaTime;
        }
    }

    private void JumpCheck()
    {
        if (Input.GetButtonDown("Jump") && groundCheck.CheckIsGrounded())
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        //animator.TriggerJump();
    }
}