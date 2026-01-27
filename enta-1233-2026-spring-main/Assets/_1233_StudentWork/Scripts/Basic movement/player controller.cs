using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(CharacterController))]

public class playercontroller : MonoBehaviour
{
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoothTime = 0.05f;
    private float _currentVelocity; 

    [SerializeField] private float speed;

    [SerializeField] private Animator _animator;

    [SerializeField] private float jumpPower;

    private int _numberOfJumps;

    [SerializeField] private int maxNumberOfJumps = 2;

    private static readonly int Speed =
        Animator.StringToHash("Speed");

    private float _gravity = -9.81f;

    [SerializeField] private float gravityMultiplier = 3.0f;

    private float _velocity;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void AnimationParamaters()
    {
        _animator.SetFloat(
            Speed, _input.sqrMagnitude);
    }

    private void Update()
    {
        ApplyGravity(); 
        ApplyRotation();
        ApplyMovement(); 
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }
        
        _direction.y = _velocity; 
    }

    private void ApplyMovement()
    { 
        _characterController.Move(motion: _direction * speed * Time.deltaTime); 
    }

    private void ApplyRotation()
    {
        if (_input.sqrMagnitude == 0) return;
        var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, y: 0.0f, z: _input.y);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.started) return;
        if (!IsGrounded() && _numberOfJumps >= maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine(WaitForLanding());

        _numberOfJumps++;
        _velocity = jumpPower;
    }

    private IEnumerator WaitForLanding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);

        _numberOfJumps = 0;
    }

    private bool IsGrounded() => _characterController.isGrounded;
}
