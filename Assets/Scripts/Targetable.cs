using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
	[SerializeField]
	protected Transform target;

	public Transform Target
	{
		get => target;
		set
		{
			if (target == value)
			{
				return;
			}

			target = value;
			OnTargetChanged?.Invoke(target);
		}
	}

	public event System.Action<Transform> OnTargetChanged;
}
