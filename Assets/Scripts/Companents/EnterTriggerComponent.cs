using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class EnterTriggerComponent : MonoBehaviour
{
    [SerializeField] private string _tag;
    [SerializeField] private UnityEvent _action;
    [SerializeField] private UnityEvent _actionExit;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_tag))
		{
			_action?.Invoke();
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag(_tag))
		{
			_actionExit?.Invoke();
		}
	}
}
