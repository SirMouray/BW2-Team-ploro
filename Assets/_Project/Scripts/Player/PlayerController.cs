using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private AnimationManager animator;

    [Header("Movement Attributes")]
    [SerializeField] private float speed = 2f;
    //[SerializeField] private float multipliedSpeed = 2f;
    private Vector3 move;
    private float horizontal;
    private float vertical;

    [Header("Rotation Attributes")]
    [SerializeField] private float rotationSmoothness = 10f;
    private Quaternion rotTarget;

    //[Header("Jump Attributes")]
    //[SerializeField] private GroundCheck groundCheck;
    //[SerializeField] private float jumpHeight = 2f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();

        //if (groundCheck == null)
        //    groundCheck = GetComponent<GroundCheck>();

        //if (animator == null)
        //    animator = GetComponent<AnimationManager>();

    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        move = new Vector3(horizontal, 0, vertical);

        //SprintCheck();

        //if (Input.GetButtonDown("Jump"))
        //    PerformJump();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (speed * Time.deltaTime));

        //animator.SetJumpState(groundCheck.CheckIsGrounded());
        //animator.JumpAnimation();

        if (move != Vector3.zero)
        {
            rotTarget = Quaternion.LookRotation(move);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, rotTarget, rotationSmoothness * Time.fixedDeltaTime));
        }
    }

    //private void SprintCheck()
    //{
    //    float currentSpeed = initialSpeed;

    //    if (Input.GetButton("Fire3"))
    //        currentSpeed *= multipliedSpeed;

    //    speed = currentSpeed;
    //}

    //private void PerformJump()
    //{
    //    if (!groundCheck.CheckIsGrounded())
    //        return;

    //    rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
    //    animator.TriggerJump();
    //}
}