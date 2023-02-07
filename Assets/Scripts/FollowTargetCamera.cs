using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class FollowTargetCamera : MonoBehaviour
{
	[SerializeField] private Transform _target;
	[SerializeField] private float _damping = 2f;

	private void LateUpdate()
	{
		var destination = new Vector3(_target.position.x, _target.position.y, transform.position.z);
		transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * _damping);


	}
}
