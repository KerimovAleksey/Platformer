using UnityEngine;
using UnityEngine.InputSystem;


public class HeroInputReader : MonoBehaviour 
{
	[SerializeField] private Hero _hero;


	/*
	// ������ �������, ������� ���������� ��� �������� �������
	private void Awake()
	{
		Debug.Log(message: "Awake");
	}

	// ���� ������ �������
	private void OnEnable()
	{
		Debug.Log("OnEnabled");
	}

	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("Start");
	}
	// ���������� ����� ���������� ���������� ������, �� ������� �� ���
	private void FixedUpdate()
	{
		Debug.Log("FixedUpdate");
	}

	// Update is called once per frame
	void Update()
    {
		// �������� ������� ������
		Debug.Log("Update");
	}
	// ����� ���� ��������, ��������, ��� ���������� ������ �� �������
	private void LateUpdate()
	{
		Debug.Log("LateUpdate");
	}
	// ��� ���������� ��� ����������� �������
	private void OnDisable()
	{
		Debug.Log("OnDisabled");
	}
	// ��� ����������� ���� ��� �������
	private void OnDestroy()
	{
		Debug.Log("OnDestroy");
	}
	*/ // ��� ������ �� �������

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
