using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Speech : MonoBehaviour
{
	[SerializeField]
	private Text nameText;

	[SerializeField]
	private Text speechText;

	[SerializeField]
	private CanvasGroup group;

	[SerializeField]
	private float animationSpeed;

	private string name;
	private string speech;
	private Coroutine anim;

	private void Awake()
	{
		Hide();
	}

	public void Active(string name, string speech)
	{
		group.alpha = 1f;
		this.name = name;
		this.speech = speech;

		StartAnimation();
		//this.nameText.text = name;
		//this.speechText.text = speech;
	}

	public void Deactive()
	{
		group.alpha = 0.5f;
		StopAnimation();
		this.speechText.text = speech;
	}

	public void Hide()
	{
		group.alpha = 0f;
	}

	private void StartAnimation()
	{
		StopAnimation();
		anim = StartCoroutine(SpeechAnimation());
	}

	private void StopAnimation()
	{
		if (anim != null)
		{
			StopCoroutine(anim);
			anim = null;
		}
	}

	private IEnumerator SpeechAnimation()
	{
		string s = speech + " ▼";
		
		for (int i = 0; i < s.Length; i++)
		{
			yield return new WaitForSeconds(animationSpeed);
			speechText.text = s.Substring(0, i + 1);
		}
	}
}
