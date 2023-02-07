using UnityEngine;

public class DestroyObjectComponent : MonoBehaviour
{
    [SerializeField] private GameObject _objectToDestroy;
    public void DestroyObhect()
    {
        Destroy(_objectToDestroy);
    }
}
