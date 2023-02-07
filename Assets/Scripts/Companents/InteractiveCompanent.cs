using UnityEngine;
using UnityEngine.Events;

public class InteractiveCompanent : MonoBehaviour
{
	[SerializeField] private UnityEvent _action;
	[SerializeField] private int _elementsCount = 1;
	[SerializeField] private GameObject _objForDestroy;
	[SerializeField] private bool _oneTimeInteractable = true;
	[SerializeField] private ParticleSystem _stopParticles;


	private static int _countOfInteracteds = 0;

	public void DoInteract()
	{
		Debug.Log("Interact successful");
		_countOfInteracteds++;
		StopParticlesSpawn();

		if (_countOfInteracteds == _elementsCount)
		{
			_action?.Invoke();
			Destroy(_objForDestroy);
		}
		if (_oneTimeInteractable)
		{
			Destroy(this);
		}
	}

	private void StopParticlesSpawn()
	{
		var _partSettingsMain = _stopParticles.main;
		var _partSettingsEmission = _stopParticles.emission;

		_partSettingsMain.startSpeed = 20;
		_partSettingsEmission.rateOverTime = 100;
		_partSettingsMain.loop = false;
	}
}
