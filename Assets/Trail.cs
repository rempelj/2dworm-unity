using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour {

	public Transform target;
	public float minDist;

	Vector3 lastPos;

	void Update()
	{
		transform.position = lastPos;
		LookAt2D(target.position);

		if (Vector3.Distance(transform.position, target.position) > minDist)
		{
			var heading = target.position - transform.position;
			var dist = heading.magnitude;
			var dir = heading / dist;
			transform.position = target.position - (dir * minDist);
			lastPos = transform.position;
		}

	}

	void LookAt2D(Vector3 lookAt)
	{
		Vector3 dir = lookAt - transform.position;
		float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
		var targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);

		transform.rotation = targetRotation;

	}
}