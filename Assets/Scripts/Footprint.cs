using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour
{
	[SerializeField]
	private TextMesh text;

	[SerializeField]
	private Transform body;

	[SerializeField]
	private float animationTime;

	private Coroutine anim;
	private Vector3 localPosition;
	private Vector3 worldPosition;

	private void Start()
	{
		if (body == null)
		{
			body = transform.parent;
		}

		if (body == null)
		{
			enabled = false;
			return;
		}

		localPosition = transform.position - body.position;

		Color color = text.color;
		color.a = 0f;
		text.color = color;
	}

	private void Update()
	{
		transform.position = worldPosition;
	}

	public void Show()
	{
		worldPosition = body.position + localPosition;
		StartAnimation();
	}

	private void StartAnimation()
	{
		StopAnimation();
		anim = StartCoroutine(Animation());
	}

	private void StopAnimation()
	{
		if (anim == null)
		{
			return;
		}

		StopCoroutine(anim);
		anim = null;
	}

	private IEnumerator Animation()
	{
		float currentTime = 0f;
		Color color = text.color;

		while (currentTime < animationTime)
		{
			yield return null;

			currentTime += Time.deltaTime;
			float t = currentTime / animationTime;

			color.a = 1f - t;
			text.color = color;
		}

		color.a = 0f;
		text.color = color;
	}
}
