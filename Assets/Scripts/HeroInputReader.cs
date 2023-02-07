using UnityEngine;
using UnityEngine.InputSystem;


public class HeroInputReader : MonoBehaviour 
{
	[SerializeField] private Hero _hero;


	/*
	// Первая функция, которая вызывается при загрузке объекта
	private void Awake()
	{
		Debug.Log(message: "Awake");
	}

	// Если объект активен
	private void OnEnable()
	{
		Debug.Log("OnEnabled");
	}

	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("Start");
	}
	// Вызывается перез физической обработкой модели, не зависит от фпс
	private void FixedUpdate()
	{
		Debug.Log("FixedUpdate");
	}

	// Update is called once per frame
	void Update()
    {
		// Основная игровая логика
		Debug.Log("Update");
	}
	// После всех апдейтов, например, для следования камеры за игроком
	private void LateUpdate()
	{
		Debug.Log("LateUpdate");
	}
	// При выключении или уничтожении объекта
	private void OnDisable()
	{
		Debug.Log("OnDisabled");
	}
	// при уничтожении игры или объекта
	private void OnDestroy()
	{
		Debug.Log("OnDestroy");
	}
	*/ // Все методы по очереди

	public void OnMovement(InputAction.CallbackContext context)
	{
		var direction = context.ReadValue<Vector2>();
		_hero.SetDirection(direction);
	}


	public void OnInteract(InputAction.CallbackContext context)
	{
		if (context.canceled)
		{
			_hero.Interact();
		}
	}
}
