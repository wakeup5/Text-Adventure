using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
	[SerializeField]
	private Footprint[] foots;

	[SerializeField]
	private float footprintLength;

	private Vector3 temp;
	private int index;

	private void Start()
	{
		temp = transform.position;
		index = 0;
	}

	private void Update()
	{
		if (Vector3.Distance(temp, transform.position) > footprintLength)
		{
			temp = transform.position;

			foots[index].gameObject.SetActive(false);
			foots[index].gameObject.SetActive(true);

			index = (index + 1) % 2;
		}
	}
}