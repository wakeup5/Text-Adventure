using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TextScriptSet : MonoBehaviour
{
	[SerializeField]
	private List<TextScript> texts;

	[SerializeField]
	private List<SelectScript> selects;

	public List<TextScript> Texts => texts;
	public List<SelectScript> Selects => selects;
}

[System.Serializable]
public class TextScript
{
	public enum ScriptType
	{
		Top,
		Bottom
	}

	[SerializeField]
	private ScriptType type;

	[SerializeField]
	private Character character;

	[SerializeField]
	[TextArea]
	private string text;

	public ScriptType Type => type;
	public Character Character => character;
	public string Text => text;
}

[System.Serializable]
public class SelectScript
{
	[SerializeField]
	private string content;

	[SerializeField]
	private UnityEvent action;

	public string Content => content;
	public UnityEvent Action => action;
}