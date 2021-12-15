using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
	PlayerInputAction _actions;
	CharacterController _controller;
	Player _player;
	Animator _animator;

	[Header("Controller")]
	[SerializeField] float _moveSpeed = 6f;

	[Tooltip("Adds to Move Speed")]
	[SerializeField] float _runSpeed = 2f;

	[SerializeField] float _jumpHeight = 3f;
	[SerializeField] float _turnSmoothTime = 0.1f;

	float _turnSmoothVelocity;
	Vector3 _move;

	[Header("Ground Check")]

	[SerializeField] Transform _groundCheck;
	[SerializeField] float _groundDistance = 0.4f;
	[SerializeField] LayerMask _groundMask;

	bool _isGrounded;

	private void Awake()
	{
		_actions = new PlayerInputAction();

		_actions.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
		_actions.Player.Move.canceled += ctx => _move = new Vector3(0.0f, _move.y, 0.0f);

		_actions.Player.Crouch.performed += ctx => OnCrouch(true);
		_actions.Player.Crouch.canceled += ctx => OnCrouch(false);

		_actions.Player.Jump.performed += ctx => OnJump();

		_actions.Player.Interact.performed += ctx => _player.OnInteraction();

		_actions.Player.Menu.performed += ctx => OnMenu();
	}

	private void Start()
	{
		_controller = GetComponent<CharacterController>();
		_animator = GetComponent<Animator>();
		_player = GetComponent<Player>();
	}

	private void Update()
	{
		#region GroundCheck & Gravity
		_isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

		if (_isGrounded && _move.y < 0)
		{
			_move.y = -2f;
		}
		_move.y += Physics.gravity.y * Time.deltaTime;
		#endregion

		#region Movement
		Vector3 direction = new Vector3(_move.x, 0f, _move.z).normalized;

		if (direction.magnitude >= 0.1f)
		{
			float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
			float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
			transform.rotation = Quaternion.Euler(0f, angle, 0f);

			Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

			_controller.Move(moveDir * _moveSpeed * Time.deltaTime);
		}

		_animator.SetFloat("moveSpeed", _controller.velocity.magnitude);

		_controller.Move(new Vector3(0.0f, _move.y, 0.0f) * Time.deltaTime);
		#endregion
	}

	private void OnMenu()
	{
		if (GameManager.Instance.GameState == GameState.PLAYING)
        {
			GameManager.Instance.SetState(GameState.PAUSE);
        }
        else if (GameManager.Instance.GameState == GameState.PAUSE)
        {
			GameManager.Instance.SetState(GameState.PLAYING);
		}
    }

	private void OnMove(Vector2 movement)
	{
		_move.x = movement.x;
		_move.z = movement.y;
	}

	private void OnCrouch(bool isCrouching)
	{
		_moveSpeed -= isCrouching ? _runSpeed : -_runSpeed;
		_animator.SetBool("isCrouching", isCrouching);
	}

	private void OnJump()
	{
		if (_isGrounded)
		{
			_move.y = Mathf.Sqrt(_jumpHeight * -2 * Physics.gravity.y);
			_animator.SetTrigger("jump");
		}
	}

	private void OnEnable()
	{
		_actions.Player.Enable();
	}

	private void OnDisable()
	{
		_actions.Player.Disable();
	}
}