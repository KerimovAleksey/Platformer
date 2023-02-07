using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
	private Vector2 _direction;
	[SerializeField] private float _speed = 5;
	[SerializeField] private float _jumpPower = 10;
	[SerializeField] private float _damageJumpPower = 80;
	[SerializeField] private float _jumpPlantPower = 20;
	[SerializeField] private float _interactionRadius = 1;
	[SerializeField] private LayerMask _interactionLayer;
	[SerializeField] private LayerCheck _groundCheck;
	[SerializeField] private SpawnComponent _footStepParticles;
	[SerializeField] private SpawnComponent _jumpParticles;


	private Collider2D[] _interactionResult = new Collider2D[1];
	private Rigidbody2D _rigidBody;
	private Animator _animator;

	private bool _isGrounded;
	private bool _allowDoubleJump;
	private bool _getDamageRadius = false;

	private static readonly int IsGroundAnimation = Animator.StringToHash("is_ground");
	private static readonly int IsRuningAnimation = Animator.StringToHash("is_running");
	private static readonly int IsVerticalMoveAnimation = Animator.StringToHash("vertical_velocity");
	private static readonly int IsDeadAnimation = Animator.StringToHash("is_dead");


	private void Awake()
	{
		_rigidBody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();

	}

	private void FixedUpdate()
	{
		var xVelocity = _direction.x * _speed;
		var yVelocity = CalculateYVelocity();
		_rigidBody.velocity = new Vector2(xVelocity, yVelocity);


		_animator.SetBool(IsRuningAnimation, _direction.x != 0);
		_animator.SetBool(IsGroundAnimation, _isGrounded);
		_animator.SetFloat(IsVerticalMoveAnimation, _rigidBody.velocity.y);

		UpdateSpriteDirection();
		
	}

	private void Update()
	{
		_isGrounded = IsGround();
	}

	public void SetDirection(Vector2 direction)
	{
		_direction = direction;
	}

	private bool IsGround()
	{
		return _groundCheck.IsTouchingLayer;
	}

	private void UpdateSpriteDirection()
	{
		if (_direction.x > 0)
		{
			transform.localScale = new Vector3(1, 1, 1);
		}
		else if (_direction.x < 0)
		{
			transform.localScale = new Vector3(-1, 1, 1);
		}
	}
	public void ForceJump()
	{
		
		_rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _jumpPlantPower);
	}

	private float CalculateYVelocity()
	{
		var yVelocity = _rigidBody.velocity.y;
		if (yVelocity > 12f && _getDamageRadius == true)
		{
			yVelocity = 12f;
			return yVelocity;
		}
		var isJumpingPressing = _direction.y > 0;
		if (_isGrounded) _allowDoubleJump = true;
		if (isJumpingPressing)
		{
			yVelocity = CalculateJumpVelocity(yVelocity);

		}
		else if (_rigidBody.velocity.y > 0.05f)
		{
			yVelocity *= 0.5f;
		}

		return yVelocity;
	}
	private float CalculateJumpVelocity(float yVelocity)
	{
		var isFalling = _rigidBody.velocity.y <= 0.05f;
		if (!isFalling) return yVelocity;
		
		if (_isGrounded)
		{
			yVelocity += _jumpPower;
		}
		else if (_allowDoubleJump)
		{
			yVelocity = _jumpPower;
			_allowDoubleJump = false;
		}
		return yVelocity;

	}
	public void TakeDamage()
	{
		_animator.SetTrigger("hit");
		_rigidBody.velocity = new Vector2(_rigidBody.velocity.x, _damageJumpPower);
	}

	public void Interact()
	{
		var size = Physics2D.OverlapCircleNonAlloc(transform.position, _interactionRadius, 
			_interactionResult, _interactionLayer);

		for (int i = 0; i < size; i++)
		{
			var interactable = _interactionResult[i].GetComponent<InteractiveCompanent>();
			if (interactable!= null)
			{
				interactable.DoInteract();
			}
		}
	}
	
	public void SpawnFootDust()
	{
		_footStepParticles.Spawn();
	}
	
	public void DamageStatus()
	{
		_getDamageRadius = !_getDamageRadius;
	}

	public void SpawnJumpDust()
	{
		_jumpParticles.Spawn();
	}

	public void OutOfLevelRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
