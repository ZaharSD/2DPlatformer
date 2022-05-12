
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
	[SerializeField] private GameObject[] _wayPoints;
	[SerializeField] private float _speed = 2f;
	
	private int _currentWayPointIndex = 0;

	private void Update()
	{
		if (Vector2.Distance(_wayPoints[_currentWayPointIndex].transform.position, transform.position) < .1f)
		{
			_currentWayPointIndex++;

			if (_currentWayPointIndex >= _wayPoints.Length)
				_currentWayPointIndex = 0;
		}
	
		MovingPlatform();
	}
	
	private void MovingPlatform()
	{
		transform.position = Vector2.MoveTowards(transform.position,
			_wayPoints[_currentWayPointIndex].transform.position, Time.deltaTime * _speed);	
	}
}
