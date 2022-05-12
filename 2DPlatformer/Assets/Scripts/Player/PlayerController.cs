
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private float _moveSpeed = 7f;
	[SerializeField] private float _jumpForce = 14f;
	[SerializeField] private LayerMask _jumpableGround;
	
	private SpriteRenderer _spriteRenderer;
	private BoxCollider2D _boxCollider2D;
	private Rigidbody2D _rigidbody2D;
	private Animator _animator;

	private float _directionX;
	private enum MovementState {idle, running, jumping, falling }

	private MovementState _movementState;
	
	private void Start()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		_boxCollider2D = GetComponent<BoxCollider2D>();
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		_directionX = Input.GetAxisRaw("Horizontal");
		if(_rigidbody2D.bodyType != RigidbodyType2D.Static)
			_rigidbody2D.velocity = new Vector2(_directionX * _moveSpeed, _rigidbody2D.velocity.y);

		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			if(_rigidbody2D.bodyType != RigidbodyType2D.Static)
				_rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
			SoundManager.Play("Jump");
		}

		UpdateAnimationState();
	}

	private void UpdateAnimationState()
	{
		if (_directionX > 0f)
		{
			_movementState = MovementState.running;
			_spriteRenderer.flipX = false;
		}
		else if (_directionX < 0f)
		{
			_movementState = MovementState.running;
			_spriteRenderer.flipX = true;

		}
		else 
			_movementState = MovementState.idle;

		if (_rigidbody2D.velocity.y > .1f)
			_movementState = MovementState.jumping;
		else if (_rigidbody2D.velocity.y < -.1f)
			_movementState = MovementState.falling;
		
		_animator.SetInteger("State", (int)_movementState);
	}

	private bool IsGrounded()
	{
		return Physics2D.BoxCast(_boxCollider2D.bounds.center, _boxCollider2D.bounds.size, 0f,
			Vector2.down, .1f, _jumpableGround);
	}

}
