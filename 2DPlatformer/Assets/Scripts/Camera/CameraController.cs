
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private Transform _targetObject;

	private void Update()
	{
		transform.position = new Vector3(_targetObject.position.x, _targetObject.position.y, -10f);
	}
}
