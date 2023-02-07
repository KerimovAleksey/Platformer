using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer))]
public class AnimatedSprite : MonoBehaviour
{
	[SerializeField] private int _frameRate;
	[SerializeField] private bool _loop;
	[SerializeField] private Sprite[] _sprites;
	[SerializeField] private UnityEvent _onComplete;

	private SpriteRenderer _renderer;
	private float _secondsPerFrame;
	private int _currentFrame;
	private float _nextFrameTime;


	//private bool _isPlaying = true;
	

	private void Start()
	{
		_renderer= GetComponent<SpriteRenderer>();
		

	}

	private void OnEnable()
	{
		_secondsPerFrame = 1f / _frameRate;
		_nextFrameTime = Time.time + _secondsPerFrame;
		_currentFrame = 0;
	}

	private void Update()
	{
		if (_nextFrameTime > Time.time) return;
		if (_currentFrame >= _sprites.Length)
		{
			if (_loop)
			{
				_currentFrame= 0;
			}
			else
			{
				enabled= false;
				//_isPlaying = false;
				_onComplete.Invoke();
					return;
			
			}
		}
		_renderer.sprite = _sprites[_currentFrame];
		_nextFrameTime += _secondsPerFrame;
		_currentFrame++;
	}
}
