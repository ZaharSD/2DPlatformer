
using UnityEngine;

public class Rotate : MonoBehaviour
{
	[SerializeField] private float _speedRotate = 2f;

	private void Update()
	{
		transform.Rotate(0, 0, 360 * _speedRotate * Time.deltaTime);
	}  
}
