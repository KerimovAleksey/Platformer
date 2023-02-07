using UnityEngine;
using UnityEngine.Events;

public class HealthComponent : MonoBehaviour
{
	[SerializeField] private int _health;
	[SerializeField] private UnityEvent _onDamageGet;
	[SerializeField] private UnityEvent _onDie;

	public void ApplyDamage(int damageValue)
	{
		_health -= damageValue;
		_onDamageGet?.Invoke();
		if (_health <= 0)
		{
			_onDie?.Invoke();
		}

	}
}
