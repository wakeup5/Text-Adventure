using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour, IPointerClickHandler
{
	[SerializeField]
	private Speech topSpeech;

	[SerializeField]
	private Speech bottomSpeech;

	[SerializeField]
	private Menu menu;

	private TextScriptSet script;
	private int num;

	private void Awake()
	{
		menu.OnSelected += OnMenuSelected;

		menu.Hide();
		topSpeech.Hide();
		bottomSpeech.Hide();
	}

	private void OnDestroy()
	{
		menu.OnSelected -= OnMenuSelected;	
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (script != null)
			{
				OnNext();
			}
		}
	}

	private void OnNext()
	{
		int prev = num;
		num++;

		if (script.Texts.Count != 0)
		{
			if (prev > -1 && prev < script.Texts.Count)
			{
				DeactiveSpeech(script.Texts[prev].Type);
			}

			if (script.Texts.Count > num)
			{
				ActiveSpeech(script.Texts[num]);
			} 
			else if (script.Selects.Count != 0)
			{
				menu.Active(script.Selects.Select(_ => _.Content).ToArray());
			}
			else
			{
				OnEnd();
			}
		}
		else
		{
			if (script.Selects.Count != 0)
			{
				menu.Active(script.Selects.Select(_ => _.Content).ToArray());
			}
			else
			{
				OnEnd();
			}
		}
	}

	private void OnEnd()
	{
		script = null;

		menu.Hide();
		topSpeech.Hide();
		bottomSpeech.Hide();
	}

	private void ActiveSpeech(TextScript script)
	{
		if (script.Type == TextScript.ScriptType.Top)
		{
			topSpeech.Active(script.Character.CharacterName, script.Text);
		}
		else
		{
			bottomSpeech.Active(script.Character.CharacterName, script.Text);
		}
	}

	private void DeactiveSpeech(TextScript.ScriptType type)
	{
		if (type == TextScript.ScriptType.Top)
		{
			topSpeech.Deactive();
		}
		else
		{
			bottomSpeech.Deactive();
		}
	}

	private void OnMenuSelected(int i)
	{
		StartCoroutine(InvokeNextFrame(script.Selects[i].Action));
		OnEnd();
	}

	public void StartScript(TextScriptSet set)
	{
		script = set;
		num = -1;
		OnNext();
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (script == null)
		{
			return;
		}

		OnNext();
	}

	private IEnumerator InvokeNextFrame(UnityEvent e)
	{
		yield return null;
		e?.Invoke();
	}
}
