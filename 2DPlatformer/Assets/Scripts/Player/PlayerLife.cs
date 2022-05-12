
using System;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
	public static event Action PlayerDied;
	
	private Rigidbody2D _rigidbody;
	private Animator _animator;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_animator = GetComponent<Animator>();
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Trap"))
			Die();
	}

	private void Die()
	{
		_rigidbody.bodyType = RigidbodyType2D.Static;
		_animator.SetTrigger("Death");
		
		SoundManager.Play("Death");
	}

	private void RestartLevel()
	{
		PlayerDied?.Invoke();
	}
}
