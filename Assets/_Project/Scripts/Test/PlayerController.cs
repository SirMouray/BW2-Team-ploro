using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : LifeController
{
    protected Rigidbody _rb;

    private float _fallHeight;
    private bool _wasGrounded;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private bool _isGrounded;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private float _groundSphere = 0.3f;
    [SerializeField] private LayerMask _groundMask;

    [SerializeField] private float _fallThreshold;
    [SerializeField] private float _minFallDmg;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GroundCheck();
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0;
        transform.forward = forward;
        

        float xDir = Input.GetAxis("Horizontal");
        float zDir = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * xDir + transform.forward * zDir;
        Vector3 velocity = direction * _speed;
        //_rb.velocity = new Vector3(_velocity.x, _rb.velocity.y, _velocity.z);

        if (direction != Vector3.zero)
        {
            transform.forward = forward;
        }
        Vector3 movement = direction * _speed * Time.fixedDeltaTime;
        Vector3 newPosition = _rb.position + movement;
        _rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && _isGrounded)
        {
            _rb.AddForce(Vector3.up*_jumpForce,ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        _wasGrounded = !_isGrounded;

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundSphere, _groundMask);


        if (!_isGrounded && _wasGrounded &&_rb.velocity.y<0 && _rb.velocity.y>-1)
        {
            float rayLength = 20f;
            Ray ray = new Ray(_groundCheck.position, Vector3.down);
            Physics.Raycast(ray, out RaycastHit hit, rayLength, _groundMask);
            //Debug.DrawRay(ray.origin, ray.direction *rayLength, Color.red);
            _fallHeight = hit.distance;
            
        }

        if (_isGrounded && !_wasGrounded)
        {
            FallDmg();
            _fallHeight = 0;
        }

    }

    private void FallDmg()
    {
        float fallDistance = _fallHeight - transform.position.y;

        if (fallDistance > _fallThreshold)
        {
            float dmg = (fallDistance - _fallThreshold) * _minFallDmg;
            RemoveHp(Mathf.RoundToInt(dmg));
        }
    }

}
