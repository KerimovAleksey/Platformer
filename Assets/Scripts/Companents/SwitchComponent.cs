using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwitchComponent : MonoBehaviour
{
	[SerializeField] private Animator _animator;
	[SerializeField] private bool _state = false;
	[SerializeField] private string _animationKey;
	

	private void Awake()
	{
		_animator = GetComponent<Animator>();
	}
	public void Switch()
	{
		_state = !_state;
		_animator.SetBool(_animationKey, _state);
		
	}

	[ContextMenu("Switch")]
	public void SwitchIt()
	{
		Switch();
	}
}
