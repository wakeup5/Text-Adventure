using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Targetable
{
	[SerializeField]
	private float smoothTime;

	private Vector3 velocity;

	private void Update()
	{
		transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
	}
}
